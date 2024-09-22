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
            _logger.Debug($"初期表示完了");
        }
        /// <summary>
        /// キーイベントトリガー
        /// ボタンをクリックしたように見せるためにJSクリックへつなげる
        /// </summary>
        /// <param name="key"></param>
        [JSInvokable]
        public async Task OnKeyPress(string key) {
            _logger.Debug($"キーイベント:{key}");
            ClickType clickType = ClickTypeConv.ConvertKeyType(key);
            if (clickType == ClickType.None) {
                _logger.Debug($"割り当てアクションなし");
                return;
            }
            _logger.Debug($"C#クリック:#btn_{clickType}");
            await _js.InvokeVoidAsync("clickBtn", $"#btn_{clickType}");
        }
        /// <summary>
        /// クリックイベントトリガー
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public void OnClick(ClickType type) {
            _logger.Debug($"クリックアクション:{type}");
            _vm.ResultAllocateAction(type);
            StateHasChanged();
        }
        public void ThemeChange() {
            if (_vm.Theme.Type == ThemeType.Light) {
                _logger.Debug($"テーマ切り替え:{ThemeType.Light}");
                _vm.Theme.SetDark();
            } else {
                _logger.Debug($"テーマ切り替え:{ThemeType.Dark}");
                _vm.Theme.SetLight();
            }
            StateHasChanged();
        }

        public async void Dispose() {
            //キーイベント削除
            await _js.InvokeVoidAsync("removeKeyListener");
        }
    }
}
