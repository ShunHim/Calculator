using WinForm.Consts;

namespace WinForm {
    internal static class Program {
        [STAThread]
        static void Main() {
            #region ���d�N���̋֎~
            Mutex mutex = new(false, AppConst.AppName);
            if (!mutex.WaitOne(0, false)) {
                MessageBox.Show($"{AppConst.AppDispName}�͊��ɋN�����Ă��܂��B");
                return;
            }
            #endregion
            ApplicationConfiguration.Initialize();
            Application.Run();
        }
    }
}