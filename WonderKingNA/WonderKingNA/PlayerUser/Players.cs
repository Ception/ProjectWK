using WonderKingNA.Login;

namespace WonderKingNA.PlayerUser {
    internal class Player {
        public User user;
        public int id;
        public string username;
        public long exp;
        public short hair, eyes;
        public short str, dex, ints, luk;
        public short vitality, wisdom;
        public int hp, mp;
        public int maxHP, maxMP;
        public int mapId;
        public int zed;
        public int attraction;
        public byte loginPosition;
        public byte level;
        public byte job;
        public byte gender;
        public float xVelocity = 2.8f;
        public float yVelocity = 16f;

        public Player() { }

        public User GetUser() {
            return user;
        }

        public void SetUser(User user) {
            this.user = user;
        }

        public int GetID() {
            return id;
        }

        public void SetID(int id) {
            this.id = id;
        }

        public string GetUsername() {
            return username;
        }

        public void SetUsername(string username) {
            this.username = username;
        }

        public long GetEXP() {
            return exp;
        }

        public void SetEXP
            (long exp) {
            this.exp = exp;
        }

        public short GetHair() {
            return hair;
        }

        public void SetHair(short hair) {
            this.hair = hair;
        }

        public short GetEyes() {
            return eyes;
        }

        public void SetEyes(short eyes) {
            this.eyes = eyes;
        }

        public short GetStr() {
            return str;
        }

        public void SetStr(short str) {
            this.str = str;
        }

        public short GetDex() {
            return dex;
        }

        public void SetDex(short dex) {
            this.dex = dex;
        }

        public short GetInt() {
            return ints;
        }

        public void SetInt(short ints) {
            this.ints = ints;
        }

        public short GetLuk() {
            return luk;
        }

        public void SetLuk(short luk) {
            this.luk = luk;
        }

        public short GetVitality() {
            return vitality;
        }

        public void SetVitality(short vitality) {
            this.vitality = vitality;
        }

        public short GetWisdom() {
            return wisdom;
        }

        public void SetWisdom(short wisdom) {
            this.wisdom = wisdom;
        }

        public int GetHP() {
            return hp;
        }

        public void SetHP(int hp) {
            this.hp = hp;
        }

        public int GetMP() {
            return mp;
        }

        public void SetMP(int mp) {
            this.mp = mp;
        }

        public int GetMaxHP() {
            return maxHP;
        }

        public void SetMaxHP(int maxHP) {
            this.maxHP = maxHP;
        }

        public int GetMaxMP() {
            return maxMP;
        }

        public void setMaxMp(int maxMp) {
            this.maxMP = maxMp;
        }

        public int GetMapID() {
            return mapId;
        }

        public void SetMapID(int mapId) {
            this.mapId = mapId;
        }

        public int GetZed() {
            return zed;
        }

        public void SetZed(int zed) {
            this.zed = zed;
        }

        public int GetAttraction() {
            return attraction;
        }

        public void SetAttraction(int attraction) {
            this.attraction = attraction;
        }

        public byte GetLoginPosition() {
            return loginPosition;
        }

        public void SetLoginPosition(byte loginPosition) {
            this.loginPosition = loginPosition;
        }

        public byte GetLevel() {
            return level;
        }

        public void SetLevel(byte level) {
            this.level = level;
        }

        public byte GetJob() {
            return job;
        }

        public void SetJob(byte job) {
            this.job = job;
        }

        public byte GetGender() {
            return gender;
        }

        public void setGender(byte gender) {
            this.gender = gender;
        }
    }
}
