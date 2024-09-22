namespace WinForm.Enums {
    public enum ClickType {
        None,

        Delete,
        Backspace,
        Enter,

        Key0,
        Key1,
        Key2,
        Key3,
        Key4,
        Key5,
        Key6,
        Key7,
        Key8,
        Key9,

        KeyDot,
        KeyPM,

        KeyAdd,
        KeySubstract,
        KeyMultiply,
        KeyDivide,
    }
    public class ClickTypeConv() {
        /// <summary>
        /// 入力キーをenum変換
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ClickType ConvertKeyType(string key) {
            return key switch {
                "0" => ClickType.Key0,
                "1" => ClickType.Key1,
                "2" => ClickType.Key2,
                "3" => ClickType.Key3,
                "4" => ClickType.Key4,
                "5" => ClickType.Key5,
                "6" => ClickType.Key6,
                "7" => ClickType.Key7,
                "8" => ClickType.Key8,
                "9" => ClickType.Key9,
                "." => ClickType.KeyDot,
                "+" => ClickType.KeyAdd,
                "-" => ClickType.KeySubstract,
                "*" => ClickType.KeyMultiply,
                "/" => ClickType.KeyDivide,
                "Enter" => ClickType.Enter,
                "Backspace" => ClickType.Backspace,
                "Delete" => ClickType.Delete,
                _ => ClickType.None,
            };
        }
    }
}
