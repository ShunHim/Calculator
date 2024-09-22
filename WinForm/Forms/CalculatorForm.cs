using log4net;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WinForm.Components;
using WinForm.Services;

namespace WinForm.Forms {
    public partial class CalculatorForm : Form {
        public CalculatorForm() {
            InitializeComponent();
            #region サービス構成
            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            //log4net
            services.AddSingleton(provider => LogManager.GetLogger(typeof(CalculatorForm)));
            //電卓ビューモデル
            services.AddSingleton<CalculatorVM>();
            //コマンドパターン
            services.AddSingleton<AddCommand>();
            services.AddSingleton<SubtractCommand>();
            services.AddSingleton<MultiplyCommand>();
            services.AddSingleton<DivideCommand>();
            services.AddSingleton<CalcInvoker>();
            #endregion
            #region Blazor構成
#if DEBUG
            //開発者ツールでデバッグできるようにする(F12キー)
            services.AddBlazorWebViewDeveloperTools();
#endif
            blazorWebView1.HostPage = "wwwroot\\index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<Calculator>("#app");
            #endregion
            //初期サイズ
            this.Size = new Size(350, 550);
            //最小サイズ
            this.MinimumSize = new Size(350, 550);
        }
    }
}
