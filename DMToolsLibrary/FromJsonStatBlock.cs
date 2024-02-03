namespace DMToolsLibrary
{
    public class FromJsonStatBlock
    {
        public string name { get; set; }

        public string size { get; set; }

        public string type { get; set; }

        public int hitPoints { get; set; }

        public int hitDice { get; set; }

        public string strPoints { get; set; }

        public string dexPoints { get; set; }

        public string conPoints { get; set; }

        public string intPoints { get; set; }

        public string wisPoints { get; set; }

        public string chaPoints { get; set; }

        public string blindsight { get; set; }

        public bool blind { get; set; }

        public string darkvision { get; set; }

        public string tremorsense { get; set; }

        public string truesight { get; set; }

        public string telepathy { get; set; }

        public string hpText { get; set; }

        public string speedDesc { get; set; }

        public string alignment { get; set; }

        public string speed { get; set; }

        public string burrowSpeed { get; set; }

        public string flySpeed { get; set; }

        public string climbSpeed { get; set; }

        public string swimSpeed { get; set; }

        public bool hover { get; set; }

        public Dictionary<string, string>[] languages { get; set; }
        public string tag { get; set; }

        public string cr { get; set; }

        public string customCr { get; set; }

        public int customProf { get; set; }

        public Dictionary<string, string>[] abilities { get; set; }

        public Dictionary<string, string>[] actions { get; set; }

        public Dictionary<string, string>[] bonusActions { get; set; }

        public Dictionary<string, string>[] reactions { get; set; }

        public Dictionary<string, string>[] legendaries { get; set; }

        public Dictionary<string, string>[] mythics { get; set; }

        public Dictionary<string, string>[] lairs { get; set; }

        public Dictionary<string, string>[] regionals { get; set; }

        public Dictionary<string, string>[] sthrows { get; set; }

        public Dictionary<string, string>[] skills { get; set; }

        public Dictionary<string, string>[] damageTypes { get; set; }

        public Dictionary<string, string>[] specialdamage { get; set; }

        public Dictionary<string, string>[] conditions { get; set; }

        public string armorName { get; set; }

        public int shieldBonus { get; set; }

        public int natArmorBonus { get; set; }

        public string otherArmorDesc { get; set; }

        public bool customHp { get; set; }

        public bool customSpeed { get; set; }

        public bool isLegendary { get; set; }

        public string legendariesDescription { get; set; }

        public bool isLair { get; set; }

        public string lairDescription { get; set; }

        public string lairDescriptionEnd { get; set; }

        public bool isMythic { get; set; }

        public string mythicDescription { get; set; }

        public bool isRegional { get; set; }

        public string regionalDescription { get; set; }

        public string regionalDescriptionEnd { get; set; }

        public string[] properties { get; set; }

        public string understandsBut { get; set; }

        public string shortName { get; set; }

        public string pluralName { get; set; }

        public bool doubleColumns { get; set; }

        public int separationPoint { get; set; }

        public object[] damage { get; set; }

    }
}
