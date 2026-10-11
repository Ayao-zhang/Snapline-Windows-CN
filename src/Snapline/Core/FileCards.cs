using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snapline.Core;

/// <summary>Safe previews for files copied from Explorer. The original file is never moved or deleted.</summary>
public static class FileCards
{
    public static string Folder => Path.Combine(Settings.Folder, "FileCards");
    public static bool Is(string previewPath) => Settings.Current.FileCards.ContainsKey(previewPath);
    public static string? Source(string previewPath) => Settings.Current.FileCards.TryGetValue(previewPath, out var source) ? source : null;

    public static string? Create(string sourcePath)
    {
        if (!File.Exists(sourcePath)) return null;
        sourcePath = Path.GetFullPath(sourcePath);
        if (Settings.Current.FileCards.Values.Any(p => string.Equals(p, sourcePath, StringComparison.OrdinalIgnoreCase))) return null;
        Directory.CreateDirectory(Folder);
        var preview = Path.Combine(Folder, $"File {DateTime.Now:yyyyMMdd-HHmmssfff}.png");
        try
        {
            Render(sourcePath, preview);
            Settings.Current.FileCards[preview] = sourcePath;
            Settings.Current.Save();
            return preview;
        }
        catch (Exception e)
        {
            Log.Error($"Could not create file card: {e.Message}");
            try { File.Delete(preview); } catch { }
            return null;
        }
    }

    public static void Forget(string previewPath)
    {
        if (!Settings.Current.FileCards.Remove(previewPath)) return;
        Settings.Current.Save();
        try { File.Delete(previewPath); } catch { }
    }

    private static void Render(string sourcePath, string previewPath)
    {
        const int width = 640, height = 420;
        var visual = new DrawingVisual();
        using (var context = visual.RenderOpen())
        {
            context.DrawRoundedRectangle(new SolidColorBrush(Color.FromRgb(244, 240, 232)), new Pen(new SolidColorBrush(Color.FromRgb(205, 195, 178)), 3), new Rect(8, 8, width - 16, height - 16), 24, 24);
            var extension = Path.GetExtension(sourcePath).TrimStart('.').ToUpperInvariant();
            var title = string.IsNullOrWhiteSpace(extension) ? "FILE" : extension;
            DrawText(context, title, 72, 68, 76, FontWeights.Bold, new SolidColorBrush(Color.FromRgb(116, 77, 42)), width - 144);
            DrawText(context, Path.GetFileName(sourcePath), 72, 250, 27, FontWeights.Normal, new SolidColorBrush(Color.FromRgb(62, 55, 45)), width - 144);
        }
        var bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
        bitmap.Render(visual);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using var stream = File.Create(previewPath);
        encoder.Save(stream);
    }

    private static void DrawText(DrawingContext context, string text, double x, double y, double size, FontWeight weight, Brush brush, double maxWidth)
    {
        var formatted = new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Segoe UI"), size, brush, 1.0)
        { MaxTextWidth = maxWidth, Trimming = TextTrimming.CharacterEllipsis };
        context.DrawText(formatted, new Point(x, y));
    }
}
