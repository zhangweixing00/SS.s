using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//配置组件信息，一个组件的版本信息主要包括以下四个价值观：Major Version(主要版本),Minor Version(次要版本),Build Number(版本号),Revision(修订)

[assembly:AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly:AssemblyCompany("朗形网络")]
[assembly:AssemblyProduct("试镜成")]
[assembly: AssemblyCopyright("Copyright © www.shijingcheng.cc 2014-2015")]
[assembly:AssemblyTrademark("")]
[assembly:AssemblyCulture("")]

//Log4net无法输出日志，找不到原因
//[assembly:log4net.Config.XmlConfigurator(ConfigFile="Config/log4net.config",Watch=true)]