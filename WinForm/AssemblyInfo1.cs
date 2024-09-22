using System.Runtime.InteropServices;

// このような SDK スタイルのプロジェクトの場合、以前はこのファイルで定義していたいくつかのアセンブリ属性がビルド時に自動的に追加されて、プロジェクトのプロパティで定義されている値がそれに設定されるようになりました。組み込まれる属性と、このプロセスをカスタマイズする方法の詳細については、次を参照してください:
// https://aka.ms/assembly-info-properties


// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントから参照できなくなります。このアセンブリ内の型に COM からアクセスする必要がある場合は、その型の
// ComVisible 属性を true に設定してください。

[assembly: ComVisible(false)]

// このプロジェクトが COM に公開される場合、次の GUID が typelib の ID になります。

[assembly: Guid("a52e5288-efaf-4db8-964a-6fc13c283790")]

// log4net構成
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]