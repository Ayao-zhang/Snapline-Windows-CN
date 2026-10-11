using System.Globalization;
using System.Windows;
using Snapline.Core;

namespace Snapline.UI;

/// <summary>
/// Every word the app shows, in English, Arabic and Simplified Chinese. The language follows
/// Windows unless chosen in Settings.
/// </summary>
public static class Strings
{
    public static event Action? LanguageChanged;

    /// <summary>"en", "ar" or "zh".</summary>
    public static string Language { get; private set; } = Resolve();

    public static bool IsRtl => Language == "ar";
    public static FlowDirection Flow => IsRtl ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

    public static void Refresh()
    {
        var was = Language;
        Language = Resolve();
        if (was != Language) LanguageChanged?.Invoke();
    }

    private static string Resolve()
    {
        var chosen = Core.Settings.Current.Language;
        if (chosen is "en" or "ar" or "zh") return chosen;
        return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar" ? "ar" : "en";
    }

    private static string L(string en) => Language switch
    {
        "ar" when Ar.TryGetValue(en, out var ar) => ar,
        "zh" when Zh.TryGetValue(en, out var zh) => zh,
        _ => en,
    };

    public const string AppName = "Snapline";
    public static string Tagline => L("Screenshots, hung out to dry.");

    public static string ShowLine => L("Show line");
    public static string HideLine => L("Hide line");
    public static string TakeEverythingDown => L("Take everything down");
    public static string NewCapture => L("New capture");
    public static string NewCaptureTip => L("Click to take a new screenshot (Win+Shift+S)");
    public static string CatchClipboard => L("Catch clipboard captures");
    public static string CatchClipboardTip => L("Win+Shift+S and PrtScn captures hang even when no file is saved");
    public static string StayDownWhileUnused => L("Stay down until each capture is used");
    public static string StayDownWhileUnusedTip => L("The line waits while a capture has not been copied, dragged or opened");
    public static string TakeDownAfterDrag => L("Take down after dragging into an app");
    public static string TakeDownAfterDragTip => L("A photo dropped into a chat or an app leaves the line, like one saved to a folder");
    public static string RevealAtTopEdge => L("Bring the line down when the pointer rests at the top edge");
    public static string RevealAtTopEdgeTip => L("Hold the pointer still against the top of the screen for half a second. Off, the shortcut and the tray icon show the line.");
    public static string OpenScreenshotsFolder => L("Open Screenshots folder");
    public static string OpenInboxFolder => L("Open caught captures folder");
    public static string Sounds => L("Sounds");
    public static string StartWithWindows => L("Start with Windows");
    public static string Settings => L("Settings…");
    public static string About => L("About Snapline");
    public static string Quit => L("Quit Snapline");

    public static string Copy => L("Copy");
    public static string CopyText => L("Copy text");
    public static string Open => L("Open");
    public static string Edit => L("Edit");
    public static string MarkUp => L("Mark up");
    public static string EditInPaint => L("Edit in Paint");
    public static string Pen => L("Pen");
    public static string Highlighter => L("Highlighter");
    public static string Circle => L("Circle");
    public static string Box => L("Box");
    public static string Arrow => L("Arrow");
    public static string TextTool => L("Text");
    public static string Blur => L("Blur");
    public static string NewNote => L("New note");
    public static string Menu => L("Menu");
    public static string EditNote => L("Edit note");
    public static string NoteColour => L("Note colour");
    public static string NotePlaceholder => L("Write a note…");
    public static string NoteName(string key) => L(key switch { "yellow" => "Yellow", "pink" => "Pink", "blue" => "Blue", "green" => "Green", "orange" => "Orange", _ => key });
    public static string Colour => L("Colour");
    public static string Thickness => L("Thickness");
    public static string Undo => L("Undo");
    public static string Redo => L("Redo");
    public static string Revert => L("Revert to original");
    public static string Done => L("Done");
    public static string Saved => L("Saved");
    public static string Reverted => L("Back to the original");
    public static string CouldNotSave => L("Could not save");
    public static string ShowInExplorer => L("Show in Explorer");
    public static string KeepOnLine => L("Keep on the line");
    public static string SaveToDesktop => L("Save to Desktop");
    public static string SaveToScreenshots => L("Save to Pictures\\Screenshots");
    public static string Discard => L("Discard");
    public static string TakeDown => L("Take down");
    public static string MoveToRecycleBin => L("Move to Recycle Bin");

    public static string Hint => L("Take a screenshot and it will hang here");
    public static string Copied => L("Copied");
    public static string TextCopied => L("Text copied");
    public static string JustNow => L("just now");
    public static string MinutesAgo => L("{0} min ago");
    public static string HoursAgo => L("{0} h ago");

    public static string SettingsTitle => L("Settings");
    public static string SectionLine => L("The line");
    public static string SectionLook => L("Look");
    public static string SectionCaptures => L("Captures");
    public static string SectionGeneral => L("General");
    public static string Shortcut => L("Show or hide the line");
    public static string ShortcutTip => L("Click here and press the keys you want, like Ctrl+Alt+T");
    public static string LineDistance => L("Distance from the top of the screen");
    public static string LineDistanceTip => L("You can also drag the line itself up or down");
    public static string RopeColor => L("Line colour");
    public static string PegStyle => L("Clothespins");
    public static string Bows => L("Bows at the ends of the line");
    public static string AutoArrange => L("Arrange photos evenly along the line");
    public static string AutoArrangeTip => L("Off, each photo stays where you put it");
    public static string Appearance => L("Appearance");
    public static string LanguageLabel => L("Language");
    public static string Auto => L("Follow Windows");
    public static string Light => L("Light");
    public static string Dark => L("Dark");
    public static string CaughtCapturesFolder => L("Caught captures are saved to");
    public static string Change => L("Change…");
    public static string InboxFolderRefused => L("Caught captures need a folder of their own, because discarding one sends it to the Recycle Bin. Pick a folder that is not your Desktop, Pictures, Screenshots or a watched folder, and not a parent of them.");
    public static string WatchFoldersLabel => L("Folders watched for new screenshots");
    public static string AddFolder => L("Add folder…");
    public static string RemoveFolder => L("Remove");
    public static string SettingsFooter => L("Changes apply right away. Everything lives in {0}.");

    public static string WelcomeTitle => L("Snapline is on the line");
    public static string WelcomeBody => L("Take a screenshot and it hangs at the top of the screen. Rest the pointer against the top edge to bring the line down, or press {0}.");

    public static string AboutBody => L(
        "Click a photo to copy it. Press and hold to edit it. Double click to open it.\n" +
        "Drag it along the line to reorder, into an app to send a copy, into a folder to keep it, or to the Recycle Bin to let it go.\n" +
        "Rest the pointer against the top edge of the screen, or press {0}, to bring the line down.");

    // Colour and peg names
    public static string ColorName(string key) => L(key switch
    {
        "bronze" => "Bronze", "gray" => "Gray", "black" => "Black", "white" => "White", "red" => "Red",
        "blue" => "Blue", "green" => "Green", "gold" => "Gold", "pink" => "Pink", "purple" => "Purple", _ => key,
    });

    public static string PegName(string key) => L(key switch
    {
        "wood" => "Wooden", "metal" => "Aluminium", "mixed" => "Coloured plastic, mixed", "red" => "Red plastic",
        "blue" => "Blue plastic", "green" => "Green plastic", "yellow" => "Yellow plastic", _ => key,
    });

    private static readonly Dictionary<string, string> Ar = new()
    {
        ["Screenshots, hung out to dry."] = "لقطات الشاشة، معلّقة على الحبل.",
        ["Show line"] = "إظهار الحبل",
        ["Hide line"] = "إخفاء الحبل",
        ["Take everything down"] = "إنزال كل اللقطات",
        ["New capture"] = "لقطة جديدة",
        ["Click to take a new screenshot (Win+Shift+S)"] = "انقر لالتقاط لقطة شاشة جديدة (Win+Shift+S)",
        ["Catch clipboard captures"] = "التقاط صور الحافظة",
        ["Win+Shift+S and PrtScn captures hang even when no file is saved"] = "لقطات Win+Shift+S وPrtScn تُعلَّق حتى لو لم يُحفظ ملف",
        ["Stay down until each capture is used"] = "يبقى الحبل ظاهرًا حتى تُستخدم كل لقطة",
        ["The line waits while a capture has not been copied, dragged or opened"] = "ينتظر الحبل ما دامت هناك لقطة لم تُنسخ أو تُسحب أو تُفتح",
        ["Take down after dragging into an app"] = "إنزال اللقطة بعد سحبها إلى تطبيق",
        ["A photo dropped into a chat or an app leaves the line, like one saved to a folder"] = "الصورة التي تُفلت في محادثة أو تطبيق تغادر الحبل، كالتي تُحفظ في مجلد",
        ["Bring the line down when the pointer rests at the top edge"] = "إنزال الحبل عندما يستقر المؤشر عند الحافة العلوية",
        ["Hold the pointer still against the top of the screen for half a second. Off, the shortcut and the tray icon show the line."] = "ثبّت المؤشر عند أعلى الشاشة نصف ثانية. عند الإيقاف، يُظهر الحبلَ الاختصارُ وأيقونةُ شريط المهام.",
        ["Open Screenshots folder"] = "فتح مجلد لقطات الشاشة",
        ["Open caught captures folder"] = "فتح مجلد اللقطات الملتقطة",
        ["Caught captures need a folder of their own, because discarding one sends it to the Recycle Bin. Pick a folder that is not your Desktop, Pictures, Screenshots or a watched folder, and not a parent of them."] = "تحتاج اللقطات الملتقطة إلى مجلد خاص بها، لأن التخلص من لقطة يرسلها إلى سلة المحذوفات. اختر مجلدًا ليس سطح المكتب ولا الصور ولا لقطات الشاشة ولا مجلدًا مراقبًا، وليس مجلدًا يحتويها.",
        ["Sounds"] = "الأصوات",
        ["Start with Windows"] = "التشغيل مع Windows",
        ["Settings…"] = "الإعدادات…",
        ["About Snapline"] = "حول Snapline",
        ["Quit Snapline"] = "إنهاء Snapline",
        ["Copy"] = "نسخ",
        ["Copy text"] = "نسخ النص",
        ["Open"] = "فتح",
        ["Edit"] = "تحرير",
        ["Mark up"] = "تعليم",
        ["Edit in Paint"] = "تحرير في الرسام",
        ["Pen"] = "قلم",
        ["Highlighter"] = "قلم تمييز",
        ["Circle"] = "دائرة",
        ["Box"] = "مربع",
        ["Arrow"] = "سهم",
        ["Text"] = "نص",
        ["Blur"] = "تمويه",
        ["New note"] = "ملاحظة جديدة",
        ["Menu"] = "القائمة",
        ["Edit note"] = "تحرير الملاحظة",
        ["Note colour"] = "لون الملاحظة",
        ["Write a note…"] = "اكتب ملاحظة…",
        ["Yellow"] = "أصفر", ["Orange"] = "برتقالي",
        ["Colour"] = "اللون",
        ["Thickness"] = "السُّمك",
        ["Undo"] = "تراجع",
        ["Redo"] = "إعادة",
        ["Revert to original"] = "العودة إلى الأصل",
        ["Done"] = "تم",
        ["Saved"] = "تم الحفظ",
        ["Back to the original"] = "عادت إلى الأصل",
        ["Could not save"] = "تعذّر الحفظ",
        ["Show in Explorer"] = "إظهار في مستكشف الملفات",
        ["Keep on the line"] = "إبقاؤها على الحبل",
        ["Save to Desktop"] = "حفظ على سطح المكتب",
        ["Save to Pictures\\Screenshots"] = "حفظ في الصور\\لقطات الشاشة",
        ["Discard"] = "تجاهل",
        ["Take down"] = "إنزال",
        ["Move to Recycle Bin"] = "نقل إلى سلة المحذوفات",
        ["Take a screenshot and it will hang here"] = "التقط لقطة شاشة وستُعلَّق هنا",
        ["Copied"] = "تم النسخ",
        ["Text copied"] = "تم نسخ النص",
        ["just now"] = "الآن",
        ["{0} min ago"] = "قبل {0} د",
        ["{0} h ago"] = "قبل {0} س",
        ["Settings"] = "الإعدادات",
        ["The line"] = "الحبل",
        ["Look"] = "المظهر",
        ["Captures"] = "اللقطات",
        ["General"] = "عام",
        ["Show or hide the line"] = "إظهار الحبل أو إخفاؤه",
        ["Click here and press the keys you want, like Ctrl+Alt+T"] = "انقر هنا واضغط المفاتيح التي تريدها، مثل Ctrl+Alt+T",
        ["Distance from the top of the screen"] = "المسافة من أعلى الشاشة",
        ["You can also drag the line itself up or down"] = "يمكنك أيضًا سحب الحبل نفسه للأعلى أو للأسفل",
        ["Line colour"] = "لون الحبل",
        ["Clothespins"] = "المشابك",
        ["Bows at the ends of the line"] = "عُقد على طرفَي الحبل",
        ["Arrange photos evenly along the line"] = "ترتيب الصور بالتساوي على طول الحبل",
        ["Off, each photo stays where you put it"] = "عند الإيقاف، تبقى كل صورة حيث وضعتها",
        ["Appearance"] = "السمة",
        ["Language"] = "اللغة",
        ["Follow Windows"] = "حسب Windows",
        ["Light"] = "فاتح",
        ["Dark"] = "داكن",
        ["Caught captures are saved to"] = "تُحفظ اللقطات الملتقطة في",
        ["Change…"] = "تغيير…",
        ["Folders watched for new screenshots"] = "المجلدات المراقَبة للقطات الجديدة",
        ["Add folder…"] = "إضافة مجلد…",
        ["Remove"] = "إزالة",
        ["Changes apply right away. Everything lives in {0}."] = "تُطبَّق التغييرات فورًا. كل شيء محفوظ في {0}.",
        ["Snapline is on the line"] = "Snapline جاهز",
        ["Take a screenshot and it hangs at the top of the screen. Rest the pointer against the top edge to bring the line down, or press {0}."] = "التقط لقطة شاشة وستُعلَّق أعلى الشاشة. ثبّت المؤشر عند الحافة العلوية لإنزال الحبل، أو اضغط {0}.",
        ["Click a photo to copy it. Press and hold to edit it. Double click to open it.\nDrag it along the line to reorder, into an app to send a copy, into a folder to keep it, or to the Recycle Bin to let it go.\nRest the pointer against the top edge of the screen, or press {0}, to bring the line down."] =
            "انقر على صورة لنسخها. اضغط مطوّلًا لتحريرها. انقر نقرًا مزدوجًا لفتحها.\nاسحبها على طول الحبل لإعادة الترتيب، أو إلى تطبيق لإرسال نسخة، أو إلى مجلد للاحتفاظ بها، أو إلى سلة المحذوفات للتخلص منها.\nثبّت المؤشر عند الحافة العلوية للشاشة، أو اضغط {0}، لإنزال الحبل.",
        ["Bronze"] = "برونزي", ["Gray"] = "رمادي", ["Black"] = "أسود", ["White"] = "أبيض", ["Red"] = "أحمر",
        ["Blue"] = "أزرق", ["Green"] = "أخضر", ["Gold"] = "ذهبي", ["Pink"] = "وردي", ["Purple"] = "بنفسجي",
        ["Wooden"] = "خشبي", ["Aluminium"] = "ألومنيوم", ["Coloured plastic, mixed"] = "بلاستيك ملوّن متنوّع",
        ["Red plastic"] = "بلاستيك أحمر", ["Blue plastic"] = "بلاستيك أزرق", ["Green plastic"] = "بلاستيك أخضر", ["Yellow plastic"] = "بلاستيك أصفر",
    };

    private static readonly Dictionary<string, string> Zh = new()
    {
        ["Screenshots, hung out to dry."] = "截图，晾在这里。",
        ["Show line"] = "显示晾衣绳", ["Hide line"] = "隐藏晾衣绳",
        ["Take everything down"] = "取下全部截图", ["New capture"] = "新建截图",
        ["Click to take a new screenshot (Win+Shift+S)"] = "点击进行新的截图（Win+Shift+S）",
        ["Catch clipboard captures"] = "捕获剪贴板截图",
        ["Win+Shift+S and PrtScn captures hang even when no file is saved"] = "即使没有保存文件，Win+Shift+S 和 PrtScn 截图也会挂在这里",
        ["Stay down until each capture is used"] = "每张截图被使用前保持展开",
        ["The line waits while a capture has not been copied, dragged or opened"] = "只要截图还没有被复制、拖拽或打开，晾衣绳就会保持展开",
        ["Take down after dragging into an app"] = "拖入应用后取下截图",
        ["A photo dropped into a chat or an app leaves the line, like one saved to a folder"] = "图片拖入聊天窗口或应用后会从晾衣绳上取下，就像保存到文件夹一样",
        ["Bring the line down when the pointer rests at the top edge"] = "鼠标停在屏幕顶边时显示晾衣绳",
        ["Hold the pointer still against the top of the screen for half a second. Off, the shortcut and the tray icon show the line."] = "将鼠标停在屏幕顶边半秒。关闭后，可通过快捷键或托盘图标显示晾衣绳。",
        ["Open Screenshots folder"] = "打开截图文件夹", ["Open caught captures folder"] = "打开捕获截图文件夹",
        ["Caught captures need a folder of their own, because discarding one sends it to the Recycle Bin. Pick a folder that is not your Desktop, Pictures, Screenshots or a watched folder, and not a parent of them."] = "捕获的截图需要单独的文件夹，因为丢弃它们会移入回收站。请选择一个不是桌面、图片、截图文件夹或受监控文件夹，也不是它们上级目录的文件夹。",
        ["Sounds"] = "声音", ["Start with Windows"] = "随 Windows 启动", ["Settings…"] = "设置…",
        ["About Snapline"] = "关于 Snapline", ["Quit Snapline"] = "退出 Snapline",
        ["Copy"] = "复制", ["Copy text"] = "复制文字", ["Open"] = "打开", ["Edit"] = "编辑",
        ["Mark up"] = "标注", ["Edit in Paint"] = "用画图编辑", ["Pen"] = "画笔", ["Highlighter"] = "荧光笔",
        ["Circle"] = "圆形", ["Box"] = "矩形", ["Arrow"] = "箭头", ["Text"] = "文字", ["Blur"] = "模糊",
        ["New note"] = "新建便签", ["Menu"] = "菜单", ["Edit note"] = "编辑便签", ["Note colour"] = "便签颜色",
        ["Write a note…"] = "写下便签…", ["Yellow"] = "黄色", ["Pink"] = "粉色", ["Blue"] = "蓝色", ["Green"] = "绿色", ["Orange"] = "橙色",
        ["Colour"] = "颜色", ["Thickness"] = "粗细", ["Undo"] = "撤销", ["Redo"] = "重做", ["Revert to original"] = "恢复原图",
        ["Done"] = "完成", ["Saved"] = "已保存", ["Back to the original"] = "已恢复原图", ["Could not save"] = "无法保存",
        ["Show in Explorer"] = "在文件资源管理器中显示", ["Keep on the line"] = "保留在晾衣绳上",
        ["Save to Desktop"] = "保存到桌面", ["Save to Pictures\\Screenshots"] = "保存到图片\\截图",
        ["Discard"] = "丢弃", ["Take down"] = "取下", ["Move to Recycle Bin"] = "移入回收站",
        ["Take a screenshot and it will hang here"] = "截一张图，它就会挂在这里", ["Copied"] = "已复制", ["Text copied"] = "文字已复制",
        ["just now"] = "刚刚", ["{0} min ago"] = "{0} 分钟前", ["{0} h ago"] = "{0} 小时前",
        ["Settings"] = "设置", ["The line"] = "晾衣绳", ["Look"] = "外观", ["Captures"] = "截图", ["General"] = "常规",
        ["Show or hide the line"] = "显示或隐藏晾衣绳", ["Click here and press the keys you want, like Ctrl+Alt+T"] = "点击此处并按下想要的快捷键，例如 Ctrl+Alt+T",
        ["Distance from the top of the screen"] = "距离屏幕顶部", ["You can also drag the line itself up or down"] = "也可以直接上下拖动晾衣绳",
        ["Line colour"] = "晾衣绳颜色", ["Clothespins"] = "夹子", ["Bows at the ends of the line"] = "晾衣绳两端的蝴蝶结",
        ["Arrange photos evenly along the line"] = "沿晾衣绳均匀排列图片", ["Off, each photo stays where you put it"] = "关闭后，每张图片会留在你放置的位置",
        ["Appearance"] = "显示模式", ["Language"] = "语言", ["Follow Windows"] = "跟随 Windows", ["Light"] = "浅色", ["Dark"] = "深色",
        ["Caught captures are saved to"] = "捕获的截图保存到", ["Change…"] = "更改…", ["Folders watched for new screenshots"] = "监控新截图的文件夹",
        ["Add folder…"] = "添加文件夹…", ["Remove"] = "移除", ["Changes apply right away. Everything lives in {0}."] = "更改会立即生效。所有内容位于 {0}。",
        ["Snapline is on the line"] = "Snapline 已准备就绪", ["Take a screenshot and it hangs at the top of the screen. Rest the pointer against the top edge to bring the line down, or press {0}."] = "截一张图，它会挂在屏幕顶部。将鼠标停在顶边，或按下 {0}，即可显示晾衣绳。",
        ["Click a photo to copy it. Press and hold to edit it. Double click to open it.\nDrag it along the line to reorder, into an app to send a copy, into a folder to keep it, or to the Recycle Bin to let it go.\nRest the pointer against the top edge of the screen, or press {0}, to bring the line down."] =
            "点击图片即可复制。长按可以编辑，双击可以打开。\n沿晾衣绳拖动可以重新排序；拖入应用可发送副本；拖入文件夹可保存；拖入回收站可丢弃。\n将鼠标停在屏幕顶边，或按下 {0}，即可显示晾衣绳。",
        ["Bronze"] = "青铜色", ["Gray"] = "灰色", ["Black"] = "黑色", ["White"] = "白色", ["Red"] = "红色",
        ["Gold"] = "金色", ["Purple"] = "紫色", ["Wooden"] = "木质", ["Aluminium"] = "铝制",
        ["Coloured plastic, mixed"] = "混色塑料", ["Red plastic"] = "红色塑料", ["Blue plastic"] = "蓝色塑料",
        ["Green plastic"] = "绿色塑料", ["Yellow plastic"] = "黄色塑料",
    };
}
