# Snapline 中文版

Snapline 是一个常驻 Windows 桌面的截图与文件暂存工具：截图或复制文件后，它们会像晾晒在绳子上的卡片一样暂时挂在屏幕顶部，随时可以复制、打开、定位或拖拽使用。

本仓库是在 [Snapline](https://github.com/mohabujubara/snapline) 基础上的 Windows 中文本地化版本，并增加了文件复制上绳功能。

## 当前版本特性

- 简体中文界面
- 支持 Windows 10 / 11 x64
- 支持系统截图、微信截图、剪贴板截图
- 复制资源管理器中的文件后，自动生成文件卡片
- 点击文件卡片可复制原文件
- 可打开文件、在资源管理器中定位文件、拖拽到其他应用
- 文件卡片被移除时，只移除 Snapline 卡片预览，不删除原文件
- 原有截图标注、OCR、便签、拖拽和置顶能力继续保留
- 完全本地运行，不上传截图和文件

## Windows 试用

直接运行工作区中的：

`Snapline-1.6.2-zh-portable.exe`

它是免安装便携版。首次运行后，程序会出现在 Windows 通知区域。

### 截图使用

1. 使用 `Win + Shift + S`、微信截图或系统截图工具截图。
2. 截图会自动挂到屏幕顶部的 Snapline 绳子上。
3. 点击卡片复制截图，右键可以标注、打开、定位、保存或移除。

### 文件使用

1. 在资源管理器中选中文件并复制。
2. 文件会生成一张文件卡片并挂到绳子上。
3. 点击卡片，可以把原文件重新复制到剪贴板。
4. 也可以右键打开、定位文件，或直接拖拽到应用中。

原文件不会被移动；移除文件卡片也不会删除原文件。

## 源码构建

需要 .NET 8 SDK：

```powershell
dotnet build src\Snapline\Snapline.csproj -c Release
dotnet publish src\Snapline\Snapline.csproj -c Release -r win-x64 `
  -p:PublishSingleFile=true `
  -p:IncludeNativeLibrariesForSelfExtract=true `
  -p:EnableCompressionInSingleFile=true `
  --self-contained true
```

输出文件位于 `dist` 发布目录。

## 数据位置

Snapline 的设置、截图和文件卡片预览默认保存在：

`%LOCALAPPDATA%\Snapline`

文件卡片只保存原文件路径和一张预览图，不会复制或上传原文件内容。

## 项目来源

本项目源自 [Tendedero](https://github.com/alejandrobujan/tendedero)，Windows 版本基于 [Snapline](https://github.com/mohabujubara/snapline) 开发。

## 许可证

MIT License。具体版权信息请查看 [LICENSE](LICENSE)。
