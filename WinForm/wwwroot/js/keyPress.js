//�L�[�C�x���g��C#�֓`��
window.addKeyListener = function (dotNetHelper) {
    document.addEventListener('keydown', function (event) {
        if (event.key == 'Enter') {
            event.preventDefault();
        }
        dotNetHelper.invokeMethodAsync('OnKeyPress', event.key);
    });
};
//�L�[�C�x���g�̍폜
window.removeKeyListener = function () {
    document.removeEventListener('keydown', function () { });
};
//C#����{�^������
function clickBtn(elem) {
    const button = document.querySelector(elem);
    button.click();
    button.focus();
}