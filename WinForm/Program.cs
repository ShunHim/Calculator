using WinForm.Consts;

namespace WinForm {
    internal static class Program {
        [STAThread]
        static void Main() {
            #region 多重起動の禁止
            Mutex mutex = new(false, AppConst.AppName);
            if (!mutex.WaitOne(0, false)) {
                MessageBox.Show($"{AppConst.AppDispName}は既に起動しています。");
                return;
            }
            #endregion
            ApplicationConfiguration.Initialize();
            Application.Run();
        }
    }
}