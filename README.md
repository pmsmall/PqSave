# PqSave

This program will allow you to read and write Pokémon Quest save files.

Pokémon Quest's title ID is `01005D100807A000`, and the save file is a single 512 KB file named `user`.

### Usage
````
Usage: pqsave mode [option arg]... input output [script1 (In script mode only)] [script2]...
  modes:
    d Decrypt save
    e Encrypt save
    x Export save to JSON
    i Import save from JSON
    s Script - Run scripts on an encrypted save
  options:
    -k,--key Set key, default is the key of switch version. When you use '--keyfile', use the key in file first
	--keyfile From file import key
````
## Android version

The keys of Android version are stored in /data/data/jp.pokemon.pokemonquest/shared_prefs/pqdata.xml, but it is encrypted.
This program cannot decrypt it now.

You can dump your key with [GameGuardian](https://gameguardian.net/download)
[How to use GameGuardian find key](https://gbatemp.net/threads/qedit-a-pokemon-quest-web-based-save-editor.509951/page-5#post-8150042)

Maybe the IOS version is similar.

## User Scripts
User-provided C# scripts can be run to modify the save data.

Two examples have been provided:
- [Modify ticket count](PqSave/Scripts/tickets.csx)
- [Set item counts to 999](PqSave/Scripts/items.csx)

## Running on Linux or macOS

.NET Core can run PqSave on Linux or macOS.
Make sure .NET Core is installed, open a terminal in the directory containing PqSave and run the program with `dotnet PqSave.dll`

## Building

#### Using Visual Studio 2017
1. Open `PqSave.sln` in Visual Studio
2. Run `Build Solution`

If you do not have .NET Core 2.0 or higher installed, Visual Studio will give an error saying that the `netcoreapp2.0` build failed.
The .NET Framework 4.6 build should still succeed if this happens.

If you want to change the version of .NET Core or .NET Framework, right click on the project,choose `dit (project name).csproj`, edit the `<TargetFrameworks>`.

#### Using the .NET Core SDK

1. Install the [.NET Core SDK](https://www.microsoft.com/net/download/windows)
2. Open a command prompt in the directory containing `PqSave.sln`
3. Run `dotnet build -f netcoreapp2.0`

If you have the .NET Framework 4.6 Targeting Pack installed the .NET Core SDK will also build the program for .NET Framework 4.6.

----

# PqSave

这个程序可以将加密的宝可梦探险寻宝存档文件进行解密，以允许对其数据进行修改。

在switch上面，宝可梦探险寻宝的title ID 是 `01005D100807A000`，它的存档是一个大小为512KB的`user`文件

### 用法
````
用法: pqsave 模式 [选项 参数]... 输入文件 输出文件 [脚本1 (只在脚本模式下有效)] [脚本2]...
  模式:
    d 解密存档
    e 加密存档
    x 将存档导出到JSON
    i 从JSOn导入存档
    s 在加密的存档上面允许脚本
  选项:
    -k,--key 设置密钥，默认是switch版本的密钥。当使用`--keyfile`选项时，优先使用文件中的密钥
	--keyfile 从文件导入密钥
````
## 安卓版本

安卓版本的密钥存在`/data/data/jp.pokemon.pokemonquest/shared_prefs/pqdata.xml`文件中，并且进行了加密
目前这个程序还不提供密钥的解密提取

你可以用[GameGuardian](https://gameguardian.net/download)来提取你的密钥
[使用教程](https://gbatemp.net/threads/qedit-a-pokemon-quest-web-based-save-editor.509951/page-5#post-8150042)

也许IOS版本类似

## 使用脚本
用户提供的C#脚本可以用来修改存档数据.

这里提供两个样例:
- [修改友好商店劵](PqSave/Scripts/tickets.csx)
- [把材料数量设置成999](PqSave/Scripts/items.csx)

## 在Linux或者macOS上运行

在Linux和macOS上可以通过.NET Core来运行PqSave.
首先确保安装了.NET Core，打开终端，切换到PqSave所在的目录，使用`dotnet PqSave.dll`来运行程序

## 生成

#### 通过 Visual Studio 2017
1. 在Visual Studio中打开 `PqSave.sln`
2. 运行 `生成(U)`

如果你没有安装.NET Core 2.0或者更高版本，VS会报错，提示找不到`netcoreapp2.0`环境。.NET Framework 4.6下生成类似。

如果你想更改.NET Core 或者 .NET Framework的版本，右键项目，选择`编辑 (项目名).csproj`，更改`<TargetFrameworks>`标签内的内容。

#### 使用 .NET Core SDK

1. 安装 [.NET Core SDK](https://www.microsoft.com/net/download/windows)
2. 打开命令行，切换到PqSave.sln所在目录
3. 运行 `dotnet build -f netcoreapp2.0`（2.1版本的就把2.0改成2.1）

使用.NET Framework 4.6 并且安装 .NET Core SDK 同样可以在 .NET Framework 4.6 生成目标文件.

