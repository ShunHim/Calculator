using log4net;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WinForm.Components {
    /// <summary>
    /// Calulator.razorのコードビハインド
    /// </summary>
    public partial class Calculator {
        /// <summary>
        /// ビューモデル
        /// </summary>
        [Inject]
        private CalculatorVM _vm { get; set; }
        /// <summary>
        /// log4net
        /// </summary>
        [Inject]
        private ILog _logger { get; set; }
        /// <summary>
        /// JS
        /// </summary>
        [Inject]
        private IJSRuntime _js { get; set; }

        /// <summary>
        /// 読み込み完了時
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync() {
            //キーイベントキャプチャ
            await _js.InvokeVoidAsync("addKeyListener", DotNetObjectReference.Create(this));
            //ツールチップ初期化
            await _js.InvokeVoidAsync("toolInit", null);
        }
        /// <summary>
        /// キーイベントトリガー
        /// ボタンをクリックしたように見せるためにJSクリックへつなげる
        /// </summary>
        /// <param name="key"></param>
        [JSInvokable]
        public async Task OnKeyPress(string key) {
            Console.WriteLine("デバッグ");
            _logger.Debug($"キーイベント:{key}");
        }
    }
}
