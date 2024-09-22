//キーイベントをC#へ伝搬
window.addKeyListener = function (dotNetHelper) {
    document.addEventListener('keydown', function (event) {
        if (event.key == 'Enter') {
            event.preventDefault();
        }
        dotNetHelper.invokeMethodAsync('OnKeyPress', event.key);
    });
};
//キーイベントの削除
window.removeKeyListener = function () {
    document.removeEventListener('keydown', function () { });
};
//C#からボタン押下
function clickBtn(elem) {
    const button = document.querySelector(elem);
    button.click();
    button.focus();
}