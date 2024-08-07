﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class AC
{
	private string otherArmorDesc;
	private string armorName;
	private int shieldBonus;
	private int dexBonus;
	private int naturalArmorBonus;

	private static Dictionary<string, ArmorType> nameToType = new Dictionary<string, ArmorType>
	{
		{ "none", ArmorType.None },
		{ "natural armor", ArmorType.Light },
		{ "padded armor", ArmorType.Light },
		{ "leather armor", ArmorType.Light },
		{ "studded leather", ArmorType.Light },
		{ "hide armor", ArmorType.Medium },
		{ "chain shirt", ArmorType.Medium },
		{ "scale mail", ArmorType.Medium },
		{ "breastplate", ArmorType.Medium },
		{ "half plate", ArmorType.Medium },
		{ "mage armor", ArmorType.Medium },
		{ "ring mail", ArmorType.Heavy },
		{ "chain mail", ArmorType.Heavy },
		{ "splint", ArmorType.Heavy },
		{ "plate", ArmorType.Heavy },
		{ "other", ArmorType.None },
	};

	private Dictionary<string, int> nameToAc;

	private static Dictionary<ArmorType, bool> allowsDexMod = new Dictionary<ArmorType, bool>
	{
		{ ArmorType.None, true },
		{ ArmorType.Light, true },
		{ ArmorType.Medium, true },
		{ ArmorType.MageArmor, true },
		{ ArmorType.Heavy, false },
	};

	private enum ArmorType
	{
		None = -1,
		Light = 1,
		Medium,
		Heavy,
		MageArmor,
	}

	public AC() { }

	// TODO: This will need to use the DBContext to fetch the type of armor and AC
	public AC(string otherArmorDesc, int shieldBonus, string armorName, int dexBonus, int naturalArmorBonus)
	{
		this.otherArmorDesc = otherArmorDesc;
		this.shieldBonus = shieldBonus;
		this.armorName = armorName;
		this.dexBonus = dexBonus;
		this.naturalArmorBonus = naturalArmorBonus;

		this.nameToAc = new Dictionary<string, int>
		{
			{ "none", 10 },
			{ "natural armor", 10 + naturalArmorBonus },
			{ "padded armor",11 + this.dexBonus + this.shieldBonus },
			{ "leather armor", 11 },
			{ "studded leather", 12 },
			{ "hide armor", 12 },
			{ "chain shirt", 13 },
			{ "scale mail", 14 },
			{ "breastplate", 14 },
			{ "half plate", 15 },
			{ "ring mail", 14 },
			{ "chain mail", 16 },
			{ "splint", 17 },
			{ "plate", 18 },
			{ "other", 0 },
		};

		this.ArmorName = armorName;
		this.AllowsDexMod = (dexBonus > 0) ? 1 : 0;
		this.ShieldBonus = this.shieldBonus;
		this.DexBonus = this.dexBonus;
		this.NaturalArmorBonus = this.naturalArmorBonus;
	}


	public string GetAc
	{
		get
		{
			if (this.armorName == null)
			{
				this.armorName = this.ArmorName;
			}

			if (this.shieldBonus == 0)
			{
				this.shieldBonus = this.ShieldBonus;
			}

			if (naturalArmorBonus == 0)
			{
				this.naturalArmorBonus = this.NaturalArmorBonus ?? 0;
			}

			if (nameToAc == null)
			{
				SetNameToAc(this.DexBonus ?? 0, this.ShieldBonus, this.naturalArmorBonus);
			}

			if (this.armorName.ToLower() == "other" && !string.IsNullOrEmpty(this.otherArmorDesc))
				return this.otherArmorDesc;

			if (this.armorName.ToLower() == "mage armor")
			{
				return $"{10 + this.dexBonus} ({13 + this.dexBonus} with Mage Armor)";
			}

			int ac = this.nameToAc[this.armorName] + this.shieldBonus;
			if (allowsDexMod[nameToType[this.armorName]])
			{
				ac += this.dexBonus;
			}

			return $"{ac} ({this.armorName})";
		}
	}

    private void SetNameToAc(int dexBonus, int shieldBonus, int naturalArmorBonus)
    {
        this.nameToAc = new Dictionary<string, int>
        {
            { "none", 10 + dexBonus },
            { "natural armor", 10 + naturalArmorBonus },
            { "padded armor",11 + dexBonus + shieldBonus },
            { "leather armor", 11 },
            { "studded leather", 12 },
            { "hide armor", 12 },
            { "chain shirt", 13 },
            { "scale mail", 14 },
            { "breastplate", 14 },
            { "half plate", 15 },
            { "ring mail", 14 },
            { "chain mail", 16 },
            { "splint", 17 },
            { "plate", 18 },
            { "other", 0 },
        };
    }
}
