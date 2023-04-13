

public class saveItem {
    public int level_index;
    public string save_name;
    public double save_time;
    public int save_money;
    public bool save_isHavePet;
    public bool save_isHaveAttacker;
    public bool save_isHaveBuffAura;
    public bool save_isHaveHealer;
    public bool save_bow;
    public bool save_shotgun;
    public bool save_melee;


    public saveItem(int level_index, string save_name, double save_time, int save_money, bool save_isHavePet, bool save_isHaveAttacker, bool save_isHaveBuffAura, bool save_isHaveHealer, bool save_bow, bool save_shotgun, bool save_melee)
    {
        this.level_index = level_index;
        this.save_name = save_name;
        this.save_time = save_time;
        this.save_money = save_money;
        this.save_isHaveAttacker = save_isHaveAttacker;
        this.save_isHavePet = save_isHavePet;
        this.save_isHaveBuffAura = save_isHaveBuffAura;
        this.save_isHaveHealer = save_isHaveHealer;
        this.save_bow = save_bow;
        this.save_shotgun = save_shotgun;
        this.save_melee = save_melee;
    }
}
