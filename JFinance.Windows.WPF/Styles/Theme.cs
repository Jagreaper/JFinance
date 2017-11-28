using JFinance.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JFinance.Windows.WPF.Styles
{
    public class Theme : ObservableObject
    {
        #region Fields

        [JsonIgnore]
        private string name;

        [JsonIgnore]
        private Brush accentMainBrush;

        [JsonIgnore]
        private Brush accentDarkBrush;

        [JsonIgnore]
        private Brush selectedBrush;

        [JsonIgnore]
        private Brush validBrush;

        [JsonIgnore]
        private Brush invalidBrush;

        [JsonIgnore]
        private Brush accentBrush;

        [JsonIgnore]
        private Brush markerBrush;

        [JsonIgnore]
        private Brush strongBrush;

        [JsonIgnore]
        private Brush mainBrush;

        [JsonIgnore]
        private Brush primaryBrush;

        [JsonIgnore]
        private Brush alternativeBrush;

        [JsonIgnore]
        private Brush mouseOverBrush;

        [JsonIgnore]
        private Brush basicBrush;

        [JsonIgnore]
        private Brush semiBasicBrush;

        [JsonIgnore]
        private Brush headerBrush;

        [JsonIgnore]
        private Brush complementaryBrush;

        [JsonIgnore]
        private Brush backgroundBrush;

        #endregion

        #region Properties

        public string Name
        {
            get => this.name;
            set => this.Set(ref this.name, value);
        }

        public Brush AccentMainBrush
        {
            get => this.accentMainBrush;
            set => this.Set(ref this.accentMainBrush, value);
        }

        public Brush AccentDarkBrush
        {
            get => this.accentDarkBrush;
            set => this.Set(ref this.accentDarkBrush, value);
        }

        public Brush SelectedBrush
        {
            get => this.selectedBrush;
            set => this.Set(ref this.selectedBrush, value);
        }

        public Brush ValidBrush
        {
            get => this.validBrush;
            set => this.Set(ref this.validBrush, value);
        }

        public Brush InvalidBrush
        {
            get => this.invalidBrush;
            set => this.Set(ref this.invalidBrush, value);
        }

        public Brush AccentBrush
        {
            get => this.accentBrush;
            set => this.Set(ref this.accentBrush, value);
        }

        public Brush MarkerBrush
        {
            get => this.markerBrush;
            set => this.Set(ref this.markerBrush, value);
        }

        public Brush StrongBrush
        {
            get => this.strongBrush;
            set => this.Set(ref this.strongBrush, value);
        }

        public Brush MainBrush
        {
            get => this.mainBrush;
            set => this.Set(ref this.mainBrush, value);
        }

        public Brush PrimaryBrush
        {
            get => this.primaryBrush;
            set => this.Set(ref this.primaryBrush, value);
        }

        public Brush AlternativeBrush
        {
            get => this.alternativeBrush;
            set => this.Set(ref this.alternativeBrush, value);
        }

        public Brush MouseOverBrush
        {
            get => this.mouseOverBrush;
            set => this.Set(ref this.mouseOverBrush, value);
        }

        public Brush BasicBrush
        {
            get => this.basicBrush;
            set => this.Set(ref this.basicBrush, value);
        }

        public Brush SemiBasicBrush
        {
            get => this.semiBasicBrush;
            set => this.Set(ref this.semiBasicBrush, value);
        }

        public Brush HeaderBrush
        {
            get => this.headerBrush;
            set => this.Set(ref this.headerBrush, value);
        }

        public Brush ComplementaryBrush
        {
            get => this.complementaryBrush;
            set => this.Set(ref this.complementaryBrush, value);
        }

        public Brush BackgroundBrush
        {
            get => this.backgroundBrush;
            set => this.Set(ref this.backgroundBrush, value);
        }

        #endregion
    }
}
