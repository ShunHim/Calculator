namespace WinForm.Components {
    public class Theme {
        public ThemeType Type { get; set; }
        public string Bg { get; set; } = string.Empty;
        public string Tx { get; set; } = string.Empty;
        public string Btn1 { get; set; } = string.Empty;
        public string Btn2 { get; set; } = string.Empty;
        public string Btn3 { get; set; } = string.Empty;
        public Theme(ThemeType type) {
            switch (type) {
                case ThemeType.Dark:
                    SetDark();
                    break;
                case ThemeType.Light:
                    SetLight();
                    break;
                default:
                    break;
            }
            Type = type;
        }
        /// <summary>
        /// ライトテーマ
        /// </summary>
        public void SetLight() {
            Type = ThemeType.Light;
            Bg = "bg-white";
            Tx = "text-dark";
            Btn1 = "btn-secondary btn-sub-light";
            Btn2 = "btn-secondary btn-main-light";
            Btn3 = "btn-secondary btn-acce-light";
        }
        /// <summary>
        /// ダークテーマ
        /// </summary>
        public void SetDark() {
            Type = ThemeType.Dark;
            Bg = "bg-dark";
            Tx = "text-light";
            Btn1 = "btn-secondary btn-sub-dark";
            Btn2 = "btn-secondary btn-main-dark";
            Btn3 = "btn-secondary btn-acce-dark";
        }
    }
}
