using System.Linq;
using System.Reflection.Metadata.Ecma335; // használhatok lambda kifejezést
/// <summary>
/// Minden állapot osztály őse.
/// </summary>
abstract class AbsztraktÁllapot : ICloneable
{
    // Megvizsgálja, hogy a belső állapot állapot-e.
    // Ha igen, akkor igazat ad vissza, egyébként hamisat.
    public abstract bool ÁllapotE();
    // Megvizsgálja, hogy a belső állapot célállapot-e.
    // Ha igen, akkor igazat ad vissza, egyébként hamisat.
    public abstract bool CélÁllapotE();
    // Visszaadja az alapoperátorok számát.
    public abstract int OperátorokSzáma();
    // A szuper operátoron keresztül lehet elérni az összes operátort.
    // Igazat ad vissza, ha az i.dik alap operátor alkalmazható a belső állapotra.
    // for ciklusból kell hívni 0-tól kezdve az alap operátorok számig. Pl. így:
    // for (int i = 0; i < állapot.GetNumberOfOps(); i++)
    // {
    // AbsztraktÁllapot klón=(AbsztraktÁllapot)állapot.Clone();
    // if (klón.SzuperOperátor(i))
    // {
    // Console.WriteLine("Az {0} állapotra az {1}.dik " +
    // "operátor alkalmazható", állapot, i);
    // }
    // }
    public abstract bool SzuperOperátor(int i);
    // Klónoz. Azért van rá szükség, mert némelyik operátor hatását vissza kell vonnunk.
    // A legegyszerűbb, hogy az állapotot leklónozom. Arra hívom az operátort.
    // Ha gond van, akkor visszatérek az eredeti állapothoz.
    // Ha nincs gond, akkor a klón lesz az állapot, amiből folytatom a keresést.
    // Ez sekély klónozást alkalmaz. Ha elég a sekély klónozás, akkor nem kell felülírni a gyermek osztályban.
    // Ha mély klónozás kell, és a keretrendszer szerint mindig az kell, akkor mindenképp felülírandó.
    // Akkor nem kell felülírni, ha a mély klónozás és a sekély klónozás egybe esik.
    // Amig csak int-et, bool-t, szóval alap kisbetűs típusokat használod
    // addig a sekély és a mély klónozás egybe esik, sőt még String-nél is
    // DE, ha tömböt, hagy listát, vagy bármilyen más nagybetűs típust használsz
    // akkor már nem esik egybe
    // Sekély klónozás = Shallow Copy: minden mezőt egyenlőség jellel (=) másolok
    // Mély klónozás   = Deep Copy: a referencia típusú mezőket klónozom, az érték típusú
    // mezőket ugyanúgy egyenlőség jellel (=) másolom
    public virtual object Clone() { return MemberwiseClone(); }
    // Csak akkor kell felülírni,
    // ha körfigyeléses backtracket akarunk használni,
    // vagy mélységi keresést.
    // Egyébként maradhat ez az alap implementáció.
    // Programozás technikailag ez egy kampó metódus, amit az OCP megszegése nélkül írhatok felül.
    public override bool Equals(Object a) { return false; }
    // Ha két példány egyenlő, akkor a hasítókódjuk is egyenlő.
    // Ezért, ha valaki felülírja az Equals metódust, ezt is illik felülírni.
    public override int GetHashCode() { return base.GetHashCode(); }
}

// EZ CSAK FÉLIG VAN KÉSZ
class AlakzatMozgatásÁllapot : AbsztraktÁllapot
{
    int bogyoX, bogyoY;
    int pirosX, pirosY; // felül nyitott
    int kekX, kekY; // felül nyitott
    int feketeX, feketeY; //bal oldalt nyitott;
    // a piros belefér a kékbe és a feketébe is
    // szerencsére a kék nem fér bele a feketébe
    // szerencsére a fekete nem illik bele a kékbe
    public AlakzatMozgatásÁllapot() // létrehozza a kezdő állapotot
    {
        bogyoX = 0; bogyoY = 0;
        pirosX = 0; pirosY = 2;
        kekX = 1; kekY = 1;
        feketeX = 2; feketeY = 0;
    }
    public override bool CélÁllapotE()
    {
        // kék és piros úgyanott legyen
        return kekX == pirosX && kekY == pirosY;
    }
    public override int OperátorokSzáma()
    {
        return 4; // bogyó mehet fel, le, jobbra balra
    }
    public override bool SzuperOperátor(int i)
    {
        switch (i)
        {
            case 0: return bal();
            //case 1: return jobb();
            //case 2: return le();
            //case 3: return fel();
            default: return false;
        }
    }
    // Ez alapján meg lehet írni a jobbra, fel, le-t
    // de lehet, hogy van hiba a bal-ban!!!!!
    private bool bal()
    {
        if (!preBal()) return false;
        bool beneVagyokPirosba = bogyoX == pirosX &&
                                 bogyoY == pirosY;
        bool beneVagyokKékbe = bogyoX == kekX &&
                               bogyoY == kekY;
        bool beneVagyokFeketébe = bogyoX == feketeX &&
                                  bogyoY == feketeY;
        bogyoY--;
        if (beneVagyokKékbe) kekY--;
        if (beneVagyokPirosba) pirosY--;
        // fekete balról nyitott
        if (ÁllapotE()) return true;
        return false;
    }
    private bool preBal()
    {
        // balra csak léphetek ha nincs ott a kék
        if (bogyoX == kekX && bogyoY + 1 == kekY) return false;
        // balra csak akkor léphetek, ha nincs a piros
        if (bogyoX == pirosX && bogyoY + 1 == pirosY) return false;
        // ha ott vana fekete, az nem gond
        return bogyoY > 0;
    }
    public override bool ÁllapotE()
    {
        // a feket és a kék nem lehet egy helyen
        if (feketeX == kekX && feketeY == kekY) return false;
        return true;
    }
    // felül kell írni a ToStringet
    // felül kell írni a Equlst és a GetHashCode-ot
    // nem kell felülírni a Clone-t, mert nincs tömb, se Lista
}


class Huszar
{
    public int Sor { get; set; }
    public int Oszlop { get; set; }
    public bool IsVilagos { get; set; }

    public Huszar(int sor, int oszlop, bool isFekete)
    {
        Sor = sor;
        Oszlop = oszlop;
        IsVilagos = isFekete;
    }

    public Huszar Clone()
    {
        return new Huszar(this.Sor, this.Oszlop, this.IsVilagos);
    }
}

class F2p18Állapot : AbsztraktÁllapot
{
    int[,] sakktábla = new int[,]
    {
        { 0, 0, 0 },
        { 0, 0, 0 },
        { 0, 0, 0 }
    };
    //int[,] vilagosHuszarok = new int[,]
    //{
    //    { 0, 0 },
    //    { 0, 1 },
    //    { 0, 2 }
    //};
    //int[,] sotetHuszarok = new int[,]
    //{
    //    { 2, 0 },
    //    { 2, 1 },
    //    { 2, 2 }
    //};
    List<Huszar> vilagosHuszarok = new List<Huszar>
    {
        new Huszar(0, 0, true),
        new Huszar(0, 1, true),
        new Huszar(0, 2, true)
    };
    List<Huszar> sotetHuszarok = new List<Huszar>
    {
        new Huszar(2, 0, false),
        new Huszar(2, 1, false),
        new Huszar(2, 2, false)
    };
    //bool VilagosFogELepni = true;
    List<Huszar> mostFognakLepni = new List<Huszar>();

    public F2p18Állapot()
    {
        //Console.WriteLine("Contructor starts.");

        foreach (Huszar huszar in vilagosHuszarok)
        {
            sakktábla[huszar.Sor, huszar.Oszlop] = 1;
        }
        foreach (Huszar huszar in sotetHuszarok)
        {
            sakktábla[huszar.Sor, huszar.Oszlop] = 2;
        }
        this.mostFognakLepni = this.vilagosHuszarok;
        //this.mostFogLepni = this.vilagosHuszarok[0];
        //Console.WriteLine("Contructor runs.");
    }

    public override bool CélÁllapotE()
    {
        //Console.WriteLine("CélÁllapotE runs.");

        if (vilagosHuszarok.All(h => h.Sor == 2) && sotetHuszarok.All(h => h.Sor == 0))
        {
            return true;
        }
        return false;
    }

    public override int OperátorokSzáma()
    {
        //Console.WriteLine("OperátorokSzáma runs.");

        return 8;
    }

    public override bool SzuperOperátor(int i)
    {
        switch (i)
        {
            case 0: return lóLépés(1, 2);
            case 1: return lóLépés(1, -2);
            case 2: return lóLépés(-1, 2);
            case 3: return lóLépés(-1, -2);
            case 4: return lóLépés(2, 1);
            case 5: return lóLépés(2, -1);
            case 6: return lóLépés(-2, 1);
            case 7: return lóLépés(-2, -1);
            default: return false;
        }
    }

    private void ShuffleList(List<Huszar> list)
    {
        Random rnd = new Random();
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]); // swap
        }
    }

    private bool lóLépés(int relSor, int relOszlop)
    {
        for (int index2 = 0; index2 < sakktábla.GetLength(0); index2++)
        {
            for (int j = 0; j < sakktábla.GetLength(1); j++)
            {
                Console.Write(sakktábla[index2, j] + " ");
            }
            Console.WriteLine();
        }
        //Console.WriteLine("lóLépés starts.");
        //Console.WriteLine($"mostFognakLepni.Count: {mostFognakLepni.Count}");

        // ez egy operátor, nézük meg a VakÁllapotot,
        // hogyan kell operátort írni
        //int index = 0;
        Console.WriteLine($"Világos lép-e? - {mostFognakLepni[0].IsVilagos}");
        ShuffleList(mostFognakLepni);

        Huszar mostLep = mostFognakLepni[0];
        //Console.WriteLine("Itt vagyunk a preLóLépés előtt");
        if (preLóLépés(mostLep, relSor, relOszlop))
        {
            //Console.WriteLine($"mostLep.Sor, mostLep.Oszlop: {mostLep.Sor}, {mostLep.Oszlop}");
            //Console.WriteLine($"sakktábla[mostLep.Sor, mostLep.Oszlop]: {sakktábla[mostLep.Sor, mostLep.Oszlop]}");
            sakktábla[mostLep.Sor, mostLep.Oszlop] = 0;
            mostLep.Sor += relSor;
            mostLep.Oszlop += relOszlop;
            sakktábla[mostLep.Sor, mostLep.Oszlop] = mostLep.IsVilagos ? 1 : 2;
            mostFognakLepni = mostFognakLepni == vilagosHuszarok ? sotetHuszarok : vilagosHuszarok;
            for (int index2 = 0; index2 < sakktábla.GetLength(0); index2++)
            {
                for (int j = 0; j < sakktábla.GetLength(1); j++)
                {
                    Console.Write(sakktábla[index2, j] + " ");
                }
                Console.WriteLine();
            }

            //break;
        }
        //index++;
        //while (index < mostFognakLepni.Count)
        //{
        //}

        //if (index >= mostFognakLepni.Count)
        //{
        //    Console.WriteLine("Nincs lehetőség lépni.");
        //    return false;
        //}
        //if (!preLóLépés(huszar, relSor, relOszlop)) return false;
        // állapot átmenet
        if (ÁllapotE()) return true;
        return false;
    }
    private bool preLóLépés(Huszar huszar, int relSor, int relOszlop)
    {
        //Console.WriteLine($"PreLóLépés Huszár koordináták: {huszar.Sor}, {huszar.Oszlop}");
        int újSor = huszar.Sor + relSor;
        int újOszlop = huszar.Oszlop + relOszlop;

        Console.WriteLine($"PreLóLépés honnan próbálok lépni koordináták: {huszar.Sor}, {huszar.Oszlop}");
        Console.WriteLine($"PreLóLépés hova próbálok lépni koordináták: {újSor}, {újOszlop}");
        if (újSor >= 0 && újSor < sakktábla.GetLength(0) && újOszlop >= 0 && újOszlop < sakktábla.GetLength(1))
        {
            Console.WriteLine($"PreLóLépés hova próbálok lépni érték: {sakktábla[újSor, újOszlop]}");
        }
        Console.WriteLine($"preLóLépés return: {újSor >= 0 && újSor < sakktábla.GetLength(0) && újOszlop >= 0 && újOszlop < sakktábla.GetLength(1) && sakktábla[újSor, újOszlop] == 0}");

        return újSor >= 0 && újSor < sakktábla.GetLength(0) &&
               újOszlop >= 0 && újOszlop < sakktábla.GetLength(1) &&
               sakktábla[újSor, újOszlop] == 0;
    }

    public override bool ÁllapotE()
    {
        return true;
    }

    public override string? ToString()
    {
        String ki = "";
        for (int i = 0; i < sakktábla.GetLength(0); i++)
        {
            for (int j = 0; j < sakktábla.GetLength(1); j++)
            {
                ki += sakktábla[i, j] + " ";
            }
            ki += "\n";
        }
        return ki;
    }

    public override object Clone()
    {
        // a klónom mindig úgyanolyan típusú, mint én
        // a new lefoglalja a helyet a memóriába
        F2p18Állapot myClone = new F2p18Állapot();
        // a klónom teljesen úgyanolyan, mint én
        //myClone.s = this.s;
        //myClone.sakktábla = this.sakktábla; // ez sekély klónozás
        myClone.sakktábla = this.sakktábla.Clone() as int[,];
        myClone.vilagosHuszarok = this.vilagosHuszarok.Select(h => h.Clone()).ToList();
        myClone.sotetHuszarok = this.sotetHuszarok.Select(h => h.Clone()).ToList();
        myClone.mostFognakLepni = this.mostFognakLepni.Select(h => h.Clone()).ToList();
        return myClone;
    }
}

class F1p6Állapot : AbsztraktÁllapot
{
    // a kezdő állapotot kell lekódolnom
    int[,] sakktábla = new int[6, 6];
    int huszárX, huszárY;
    public F1p6Állapot() // ő hozza létre a kezdő állapotot
    {
        for (int i = 0; i < sakktábla.GetLength(0); i++)
        {
            for (int j = 0; j < sakktábla.GetLength(1); j++)
            {
                sakktábla[i, j] = -1; // jelentése: még nem jártam ott 
            }
        }
        huszárX = 0; huszárY = 0;
        sakktábla[0, 0] = 1; // itt már jártam
    }
    public override bool CélÁllapotE()
    {
        // nincs -1
        for (int i = 0; i < sakktábla.GetLength(0); i++)
        {
            for (int j = 0; j < sakktábla.GetLength(1); j++)
            {
                if (sakktábla[i, j] == -1) return false;
            }
        }
        return true;
    }

    public override int OperátorokSzáma()
    {
        return 8;
    }

    public override bool SzuperOperátor(int i)
    {
        //Console.WriteLine("i = " + i);
        switch (i)
        {
            case 0: return lóLépés(1, 2);
            case 1: return lóLépés(1, -2);
            case 2: return lóLépés(-1, 2);
            case 3: return lóLépés(-1, -2);
            case 4: return lóLépés(2, 1);
            case 5: return lóLépés(2, -1);
            case 6: return lóLépés(-2, 1);
            case 7: return lóLépés(-2, -1);
            default: return false;
        }
    }
    private bool lóLépés(int relX, int relY)
    {
        // ez egy operátor, nézük meg a VakÁllapotot,
        // hogyan kell operátort írni
        if (!preLóLépés(relX, relY)) return false;
        // állapot átmenet
        huszárX += relX;
        huszárY += relY;
        sakktábla[huszárX, huszárY] = 1;
        if (ÁllapotE()) return true;
        return false;
    }
    private bool preLóLépés(int relX, int relY)
    {
        int újX = huszárX + relX;
        int újY = huszárY + relY;
        return újX >= 0 && újX < sakktábla.GetLength(0) &&
               újY >= 0 && újY < sakktábla.GetLength(1) &&
               sakktábla[újX, újY] == -1;
    }
    public override bool ÁllapotE()
    {
        return true;
    }
    // még ki kell dolgozni a ToStringet
    // ha lehet kör, akkor az Equals-öt is
    // Equals --> GatHashCode
    // Clone, az egész keretrendszer feltétételezi,
    // hogy jó a klónozás
    public override string ToString()
    {
        String ki = "";
        for (int i = 0; i < sakktábla.GetLength(0); i++)
        {
            for (int j = 0; j < sakktábla.GetLength(1); j++)
            {
                ki += sakktábla[i, j] == -1 ? "0" : "1";
            }
            ki += "\n";
        }
        return ki;
    }
    // mivel nem kör (nem léphetek olyan mezőre,
    // ahol már jartam),
    // ezért nem kell felülírni az Equals-t
    // De: kell klónozás
    // A keretrendszer úgy van megírva, hogy mély klónozást KELL
    // csinálni
    // azaz, ha nincs se tömb mező, se lista mező, ....
    // akkor nem nem is kell felülírni, mert szerencsére
    // az AbsztrakÁllapot osztály viszonylag jól meg van írva
    // DE SAJNOS (sír-sír) a sakktábla az tömb
    // ilyenkör a tömböt klónozni kell!!!!
    public override object Clone()
    {
        // a klónom mindig úgyanolyan típusú, mint én
        // a new lefoglalja a helyet a memóriába
        F1p6Állapot myClone = new F1p6Állapot();
        // a klónom teljesen úgyanolyan, mint én
        myClone.huszárX = this.huszárX;
        myClone.huszárY = this.huszárY;
        //myClone.sakktábla = this.sakktábla; // ez sekély klónozás
        myClone.sakktábla = this.sakktábla.Clone() as int[,];
        return myClone;
    }
}

class F1p1Állapot : AbsztraktÁllapot
{
    int[] korongok;
    static int[] cel = { 8, 7, 6, 5, 4, 3, 2, 1 };
    public F1p1Állapot()
    {
        korongok = new int[] { 1, 4, 5, 8, 2, 3, 7, 6 };
    }
    public override bool CélÁllapotE()
    {
        return Enumerable.SequenceEqual(korongok, cel);
    }
    public override int OperátorokSzáma()
    {
        return 8;
    }
    public override bool SzuperOperátor(int i)
    {
        return atfordit(i + 1);
    }
    private bool atfordit(int db)
    {
        if (!preAtfordit(db)) return false;
        //Console.WriteLine("előfeltétel igaz");
        int lépésekSzáma = db / 2;
        //Console.WriteLine("lépésekSzáma = " + lépésekSzáma);
        for (int i = 0; i < lépésekSzáma; i++)
        {
            //Console.WriteLine("i="+i);
            int index1 = korongok.Length - db + i;
            int index2 = korongok.Length - 1 - i;
            swap(korongok, index1, index2);
        }
        if (ÁllapotE()) return true;
        return false;
    }
    private void swap(int[] tomb, int i, int j)
    {
        int temp = tomb[i];
        tomb[i] = tomb[j];
        tomb[j] = temp;
    }
    private bool preAtfordit(int db)
    {
        return true;
    }
    public override bool ÁllapotE()
    {
        return true;
    }
    // ToString, Equals --> GetHashCode, Clone
    public override string ToString()
    {
        String ki = "";
        for (int i = 0; i < korongok.Length; i++)
        {
            ki += korongok[i] + ",";
        }
        return ki;
    }
    public override bool Equals(object a)
    {
        if (a == null) return false;
        if (a is not F1p1Állapot) return false;
        F1p1Állapot másikÁllapot = (F1p1Állapot)a;
        return Enumerable.SequenceEqual(
            this.korongok, másikÁllapot.korongok);
    }
    public override int GetHashCode()
    {
        return korongok.GetHashCode();
    }
    public override object Clone()
    {
        F1p1Állapot myClone = new F1p1Állapot();
        //myClone.korongok = new List<int>(this.korongok);
        myClone.korongok = (int[])this.korongok.Clone();
        return myClone;
    }
}
class F1p3Állapot : AbsztraktÁllapot
{
    // Hogyan fogok hozzá egy új Állapot osztályhoz
    // lekódolom a kezdő állapot
    // most egy tábla adatokkal, azt muszáj rögzíteni
    static int[,] tábla =
    {
        { 1, 5, 3, 4, 3, 6, 7, 1, 1, 6 },
        { 4, 4, 3, 4, 2, 6, 2, 6, 2, 5 },
        { 1, 3, 9, 4, 5, 2, 4, 2, 9, 5 },
        { 5, 2, 3, 5, 5, 6, 4, 6, 2, 4 },
        { 1, 3, 3, 2, 5, 6, 5, 2, 3, 2 },
        { 2, 5, 2, 5, 5, 6, 4, 8, 6, 1 },
        { 9, 2, 3, 6, 5, 6, 2, 2, 2, 0 }
    };
    int figuraX, figuraY;
    // a konstruktor állítja be a kezdő állapotot
    public F1p3Állapot()
    {
        figuraX = 0; figuraY = 0;
    }
    public override bool CélÁllapotE()
    {
        // ahol a figura van, ott 0 az érték
        return tábla[figuraX, figuraY] == 0;
    }

    public override int OperátorokSzáma()
    {
        return 8;
    }
    // az alap operátorokat hívja
    public override bool SzuperOperátor(int i)
    {
        switch (i)
        {
            case 0: return lép(0, 1);  // 0,1 irányba lépek
            case 1: return lép(0, -1); //
            case 2: return lép(1, 0);
            case 3: return lép(-1, 0);
            case 4: return lép(1, 1); // átlós
            case 5: return lép(1, -1);
            case 6: return lép(-1, 1);
            case 7: return lép(-1, -1);
            default: return false;
        }
    }
    // EZ EGY OPERÁTOR
    private bool lép(int irányX, int irányY)
    {
        if (!preLép(irányX, irányY)) return false;
        // állapot átmenet
        int lépésHossza = tábla[figuraX, figuraY]; // amin állok
        figuraX += lépésHossza * irányX;
        figuraY += lépésHossza * irányY;
        if (ÁllapotE()) return true;
        return false;
    }
    private bool preLép(int irányX, int irányY)
    {
        // léphetek? Igen
        return true;
    }
    public override bool ÁllapotE()
    {
        // akkor jó az állapot, ha figura fent van
        // a táblán
        // őőő melyik az X????
        return figuraX >= 0 && figuraX <= 6 &&
               figuraY >= 0 && figuraY <= 9;
    }
    // kell ToString, meg kell Equals --> GetHashCode
    public override string ToString()
    {   // minden mezőt fel kell használni
        return "(" + figuraX + "," + figuraY + ") = " + tábla[figuraX, figuraY];
    }
    // Miért kell Equals? Erre a válasz az AbsztraktÁllapot-ban van!
    // Ha visszjuthatok ugyanabba az állapotba, azaz van kör,
    // akkor érdemes felülírni. Még ekkor sem muszáj, mert a mélységi
    // korlát megvéd, de érdmes felülírni
    public override bool Equals(object a)
    {
        if (a == null) return false;
        if (!(a is F1p3Állapot)) return false; // C#: is, Java: instanceof
        //F1p3Állapot másikÁllapot = a as F1p3Állapot;
        F1p3Állapot másikÁllapot = (F1p3Állapot)a;
        // ha minden mező egyenlő, akkor egyenlőek
        return this.figuraX == másikÁllapot.figuraX &&
               this.figuraY == másikÁllapot.figuraY;
    }
    public override int GetHashCode()
    {
        return 3 * figuraX.GetHashCode() + 7 * figuraY.GetHashCode();
    }
    // Egy nagy kérdés bent engemet:
    // Miért nem írtuk felül a Clone metódust????
    // Nézzük meg az AbsztrakÁllapot osztályt
}
/// <summary>
/// A VakÁllapot csak a szemléltetés kedvért van itt.
/// Megmutatja, hogy kell az operátorokat megírni és bekötni a szuper operátorba.
/// </summary>
abstract class VakÁllapot : AbsztraktÁllapot
{
    // Itt kell megadni azokat a mezőket, amelyek tartalmazzák a belső állapotot.
    // Az operátorok belső állapot átmenetet hajtanak végre.
    // Először az alapoperátorokat kell megírni.
    // Minden operátornak van előfeltétele.
    // Minden operátor utófeltétele megegyezik az ÁllapotE predikátummal.
    // Az operátor igazat ad vissza, ha alkalmazható, hamisat, ha nem alkalmazható.
    // Egy operátor alkalmazható, ha a belső állapotra igaz
    // az előfeltétele és az állapotátmenet után igaz az utófeltétele.
    // Ez az első alapoperátor.
    private bool op1()
    {
        // Ha az előfeltétel hamis, akkor az operátor nem alkalmazható.
        if (!preOp1()) return false;
        // állapot átmenet
        //
        // TODO: Itt kell kiegészíteni a kódot!
        //
        // Utófeltétel vizsgálata, ha igaz, akkor alkalmazható az operátor.
        if (ÁllapotE()) return true;
        return false;
    }
    // Az első alapoperátor előfeltétele. Az előfeltétel neve általában ez: pre+operátor neve.
    // Ez segíti a kód megértését, de nyugodtan eltérhetünk ettől.
    private bool preOp1()
    {
        // Ha igaz az előfeltétel, akkor igazat ad vissza.
        return true;
    }
    // Egy másik operátor.
    private bool op2()
    {
        if (!preOp2()) return false;
        // Állapot átmenet:
        // TODO: Itt kell kiegészíteni a kódot!
        if (ÁllapotE()) return true;
        // Egyébként vissza kell vonni a belső állapot átmenetet:
        // TODO: Itt kell kiegészíteni a kódot!
        return false;
    }
    private bool preOp2()
    {
        // Ha igaz az előfeltétel, akkor igazat ad vissza.
        return true;
    }
    // Nézzük, mi a helyzet, ha az operátornak van paramétere.
    // Ilyenkor egy operátor több alapoperátornak felel meg.
    private bool op3(int i)
    {
        // Az előfeltételt ugyanazokkal a pereméterekkel kell hívni, mint magát az operátort.
        if (!preOp3(i)) return false;
        // Állapot átmenet:
        // TODO: Itt kell kiegészíteni a kódot!
        if (ÁllapotE()) return true;
        // egyébként vissza kell vonni a belső állapot átmenetet
        // TODO: Itt kell kiegészíteni a kódot!
        return false;
    }
    // Az előfeltétel paraméterlistája megegyezik az operátor paraméterlistájával.
    private bool preOp3(int i)
    {
        // Ha igaz az előfeltétel, akkor igazat ad vissza. Az előfeltétel függ a paraméterektől.
        return true;
    }
    // Ez a szuper operátor. Ezen keresztül lehet hívni az alapoperátorokat.
    // Az i paraméterrel mondjuk meg, hanyadik operátort akarjuk hívni.
    // Általában egy for ciklusból hívjuk, ami 0-tól az OperátorokSzáma()-ig fut.
    public override bool SzuperOperátor(int i)
    {
        switch (i)
        {
            // Itt kell felsorolnom az összes alapoperátort.
            // Ha egy új operátort veszek fel, akkor ide is fel kell venni.
            case 0: return op1();
            case 1: return op2();
            // A paraméteres operátorok több alap operátornak megfelelnek, ezért itt több sor is tartozik hozzájuk.
            // Hogy hány sor, az feladat függő.
            case 3: return op3(0);
            case 4: return op3(1);
            case 5: return op3(2);
            default: return false;
        }
    }
    // Visszaadja az alap operátorok számát.
    public override int OperátorokSzáma()
    {
        // Az utolsó case számát kell itt visszaadni.
        // Ha bővítjük az operátorok számát, ezt a számot is növelni kell.
        return 5;
    }
}
/// <summary>
/// Ez a “éhes huszár” probléma állapottér reprezentációja.
/// A huszárnak az állomás helyétől, a bal felső sarokból,
/// el kell jutnia a kantinba, ami a jobb alsó sarokban van.
/// A táblát egy (N+4)*(N+4) mátrixszal ábrázolom.
/// A külső 2 széles rész margó, a belső rész a tábla.
/// A margó használatával sokkal könnyebb megírni az ÁllapotE predikátumot.
/// A 0 jelentése üres. Az 1 jelentése, itt van a ló.
/// 3*3-mas tábla esetén a kezdő állapot:
/// 0,0,0,0,0,0,0
/// 0,0,0,0,0,0,0
/// 0,0,1,0,0,0,0
/// 0,0,0,0,0,0,0
/// 0,0,0,0,0,0,0
/// 0,0,0,0,0,0,0
/// 0,0,0,0,0,0,0
/// A fenti reprezentációból látszik, hogy elég csak a ló helyét nyilvántartani,
/// mert a táblán csak a ló van. Így a kezdő állpot (bal felső sarokból indulunk):
/// x = 2
/// y = 2
/// A célállapot (jobb alsó sarokba megyek):
/// x = N+1
/// y = N+1
/// Operátorok:
/// A lehetséges 8 ló lépés.
/// </summary>
class ÉhesHuszárÁllapot : AbsztraktÁllapot
{
    // Alapértelmezetten egy 3*3-as sakktáblán fut.
    static int N = 3;
    // A belső állapotot leíró mezők.
    int x, y;
    // Beállítja a kezdő állapotra a belső állapotot.
    public ÉhesHuszárÁllapot()
    {
        x = 2; // A bal felső sarokból indulunk, ami a margó
        y = 2; // miatt a (2,2) koordinátán van.
    }
    // Beállítja a kezdő állapotra a belső állapotot.
    // Itt lehet megadni a tábla méretét is.
    public ÉhesHuszárÁllapot(int n)
    {
        x = 2;
        y = 2;
        N = n;
    }
    public override bool CélÁllapotE()
    {
        // A jobb alsó sarok a margó miatt a (N+1,N+1) helyen van.
        return x == N + 1 && y == N + 1;
    }
    public override bool ÁllapotE()
    {
        // a ló nem a margon van
        return x >= 2 && y >= 2 && x <= N + 1 && y <= N + 1;
    }
    private bool preLóLépés(int x, int y)
    {
        // jó lólépés-e, ha nem akkor return false
        if (!(x * y == 2 || x * y == -2)) return false;
        return true;
    }
    /* Ez az operátorom, igaz ad vissza, ha alakalmazható,
    * egyébként hamisat.
    * Paraméterek:
    * x: x irányú elmozdulás
    * y: y irányú elmozdulás
    * Az előfeltétel ellenőrzi, hogy az elmozdulás lólépés-e.
    * Az utófeltétel ellenőrzi, hogy a táblán maradtunk-e.
    * Példa:
    * lóLépés(1,-2) jelentése felfelé 2-öt jobbra 1-et.
    */
    private bool lóLépés(int x, int y)
    {
        if (!preLóLépés(x, y)) return false;
        // Ha az előfeltétel igaz, akkor megcsinálom az
        // állapot átmenetet.
        this.x += x;
        this.y += y;
        // Az utófeltétel mindig megegyezik az ÁllapotE-vel.
        if (ÁllapotE()) return true;
        // Ha az utófeltétel nem igaz, akkor vissza kell csinálni.
        this.x -= x;
        this.y -= y;
        return false;
    }
    public override bool SzuperOperátor(int i)
    {
        switch (i)
        { // itt sorolom fel a lehetséges 8 lólépést
            case 0: return lóLépés(1, 2);
            case 1: return lóLépés(1, -2);
            case 2: return lóLépés(-1, 2);
            case 3: return lóLépés(-1, -2);
            case 4: return lóLépés(2, 1);
            case 5: return lóLépés(2, -1);
            case 6: return lóLépés(-2, 1);
            case 7: return lóLépés(-2, -1);
            default: return false;
        }
    }
    public override int OperátorokSzáma() { return 8; }
    // A kiíratásnál kivonom x-ből és y-ból a margó szélességét.
    public override string ToString() { return (x - 2) + " : " + (y - 2); }
    public override bool Equals(Object a)
    {
        ÉhesHuszárÁllapot aa = (ÉhesHuszárÁllapot)a;
        return aa.x == x && aa.y == y;
    }
    // Ha két példány egyenlő, akkor a hasítókódjuk is egyenlő.
    public override int GetHashCode()
    {
        return x.GetHashCode() + y.GetHashCode();
    }
}
/// <summary>
/// A "3 szerzetes és 3 kannibál" probléma állapottér reprezentációja.
/// Illetve általánosítása akárhány szerzetesre és kannibálra.
/// Probléma: 3 szerzet és 3 kannibál van a folyó bal partján.
/// Át kell juttatni az összes embert a másik partra.
/// Ehhez rendelkezésre áll egy két személyes csónak.
/// Egy ember is elég az átjutáshoz, de kettőnél több ember nem fér el.
/// Ha valaki átmegy a másik oldalra, akkor ki is kell szállni, nem maradhat a csónakban.
/// A gond ott van, hogy ha valamelyik parton több kannibál van,
/// mint szerzetes, akkor a kannibálok megeszik a szerzeteseket.
/// Kezdő állapot:
/// 3 szerzetes a bal oldalon.
/// 3 kannibál a bal oldalon.
/// A csónak a bal parton van.
/// 0 szerzetes a jobb oldalon.
/// 0 kannibál a jobb oldalon.
/// Ezt az állapotot ezzel a rendezett 5-össel írjuk le:
/// (3,3,'B',0,0)
/// A célállapot:
/// (0,0,'J',3,3)
/// Operátor:
/// Op(int sz, int k):
/// sz darab szerzetes átmegy a másik oldalra és
/// k darab kannibál átmegy a másik oldalra.
/// Lehetséges paraméterezése:
/// Op(1,0): 1 szerzetes átmegy a másik oldalra.
/// Op(2,0): 2 szerzetes átmegy a másik oldalra.
/// Op(1,1): 1 szerzetes és 1 kannibál átmegy a másik oldalra.
/// Op(0,1): 1 kannibál átmegy a másik oldalra.
/// Op(0,2): 2 kanibál átmegy a másik oldalra.
/// </summary>
class SzerzetesekÉsKannibálokÁllapot : AbsztraktÁllapot
{
    int sz; // ennyi szerzetes van összesen
    int k; // ennyi kannibál van összesen
    int szb; // szerzetesek száma a bal oldalon
    int kb; // kannibálok száma a bal oldalon
    char cs; // Hol a csónak? Értéke vagy 'B' vagy 'J'.
    int szj; // szerzetesek száma a jobb oldalon
    int kj; // kannibálok száma a jobb oldalon
    public SzerzetesekÉsKannibálokÁllapot(int sz, int k) // beállítja a kezdő állapotot
    {
        this.sz = sz;
        this.k = k;
        szb = sz;
        kb = k;
        cs = 'B';
        szj = 0;
        kj = 0;
    }
    public override bool ÁllapotE()
    { // igaz, ha a szerzetesek biztonságban vannak
        return ((szb >= kb) || (szb == 0)) &&
        ((szj >= kj) || (szj == 0));
    }
    public override bool CélÁllapotE()
    {
        // igaz, ha mindenki átért a jobb oldalra
        return szj == sz && kj == k;
    }
    private bool preOp(int sz, int k)
    {
        // A csónak 2 személyes, legalább egy ember kell az evezéshez.
        // Ezt végül is felesleges vizsgálni, mert a szuper operátor csak ennek megfelelően hívja.
        if (sz + k > 2 || sz + k < 0 || sz < 0 || k < 0) return false;
        // Csak akkor lehet átvinni sz szerzetest és
        // k kannibált, ha a csónak oldalán van is legalább ennyi.
        if (cs == 'B')
            return szb >= sz && kb >= k;
        else
            return szj >= sz && kj >= k;
    }
    // Átvisz a másik oldalra sz darab szerzetes és k darab kannibált.
    private bool op(int sz, int k)
    {
        if (!preOp(sz, k)) return false;
        SzerzetesekÉsKannibálokÁllapot mentes = (SzerzetesekÉsKannibálokÁllapot)Clone();
        if (cs == 'B')
        {
            szb -= sz;
            kb -= k;
            cs = 'J';
            szj += sz;
            kj += k;
        }
        else
        {
            szb += sz;
            kb += k;
            cs = 'B';
            szj -= sz;
            kj -= k;
        }
        if (ÁllapotE()) return true;
        szb = mentes.szb;
        kb = mentes.kb;
        cs = mentes.cs;
        szj = mentes.szj;
        kj = mentes.kj;
        return false;
    }
    public override int OperátorokSzáma() { return 5; }
    public override bool SzuperOperátor(int i)
    {
        switch (i)
        {
            case 0: return op(0, 1);
            case 1: return op(0, 2);
            case 2: return op(1, 1);
            case 3: return op(1, 0);
            case 4: return op(2, 0);
            default: return false;
        }
    }
    public override string ToString()
    {
        return szb + "," + kb + "," + cs + "," + szj + "," + kj;
    }
    public override bool Equals(Object a)
    {
        SzerzetesekÉsKannibálokÁllapot aa = (SzerzetesekÉsKannibálokÁllapot)a;
        // szj és kj számítható, ezért nem kell vizsgálni
        return aa.szb == szb && aa.kb == kb && aa.cs == cs;
    }
    // Ha két példány egyenlő, akkor a hasítókódjuk is egyenlő.
    public override int GetHashCode()
    {
        return szb.GetHashCode() + kb.GetHashCode() + cs.GetHashCode();
    }
}
/// <summary>
/// A csúcs tartalmaz egy állapotot, a csúcs mélységét, és a csúcs szülőjét.
/// Így egy csúcs egy egész utat reprezentál a start csúcsig.
/// </summary>
class Csúcs
{
    // A csúcs tartalmaz egy állapotot, a mélységét és a szülőjét
    AbsztraktÁllapot állapot;
    int mélység;
    Csúcs szülő; // A szülőkön felfelé haladva a start csúcsig jutok.
                 // Konstruktor:
                 // A belső állapotot beállítja a start csúcsra.
                 // A hívó felelőssége, hogy a kezdő állapottal hívja meg.
                 // A start csúcs mélysége 0, szülője nincs.
    public Csúcs(AbsztraktÁllapot kezdőÁllapot)
    {
        állapot = kezdőÁllapot;
        mélység = 0;
        szülő = null;
    }
    // Egy új gyermek csúcsot készít.
    // Erre még meg kell hívni egy alkalmazható operátor is, csak azután lesz kész.
    public Csúcs(Csúcs szülő)
    {
        állapot = (AbsztraktÁllapot)szülő.állapot.Clone();
        mélység = szülő.mélység + 1;
        this.szülő = szülő;
    }
    public Csúcs GetSzülő() { return szülő; }
    public int GetMélység() { return mélység; }
    public bool TerminálisCsúcsE() { return állapot.CélÁllapotE(); }
    public int OperátorokSzáma() { return állapot.OperátorokSzáma(); }
    public bool SzuperOperátor(int i) { return állapot.SzuperOperátor(i); }
    public override bool Equals(Object obj)
    {
        Csúcs cs = (Csúcs)obj;
        return állapot.Equals(cs.állapot);
    }
    public override int GetHashCode() { return állapot.GetHashCode(); }
    public override String ToString() { return állapot.ToString(); }
    // Alkalmazza az összes alkalmazható operátort.
    // Visszaadja az így előálló új csúcsokat.
    public List<Csúcs> Kiterjesztes()
    {
        List<Csúcs> újCsúcsok = new List<Csúcs>();
        for (int i = 0; i < OperátorokSzáma(); i++)
        {
            // Új gyermek csúcsot készítek.
            Csúcs újCsúcs = new Csúcs(this);
            // Kiprobálom az i.dik alapoperátort. Alkalmazható?
            if (újCsúcs.SzuperOperátor(i))
            {
                // Ha igen, hozzáadom az újakhoz.
                újCsúcsok.Add(újCsúcs);
            }
        }
        return újCsúcsok;
    }
}
/// <summary>
/// Minden gráfkereső algoritmus őse.
/// A gráfkeresőknek csak a Keresés metódust kell megvalósítaniuk.
/// Ez visszaad egy terminális csúcsot, ha talált megoldást, egyébként null értékkel tér vissza.
/// A terminális csúcsból a szülő referenciákon felfelé haladva áll elő a megoldás.
/// </summary>
abstract class GráfKereső
{
    private Csúcs startCsúcs; // A start csúcs csúcs.
                              // Minden gráfkereső a start csúcsból kezd el keresni.
    public GráfKereső(Csúcs startCsúcs)
    {
        this.startCsúcs = startCsúcs;
    }
    // Jobb, ha a start csúcs privát, de a gyermek osztályok lekérhetik.
    protected Csúcs GetStartCsúcs() { return startCsúcs; }
    /// Ha van megoldás, azaz van olyan út az állapottér gráfban,
    /// ami a start csúcsból egy terminális csúcsba vezet,
    /// akkor visszaad egy megoldást, egyébként null.
    /// A megoldást egy terminális csúcsként adja vissza.
    /// Ezen csúcs szülő referenciáin felfelé haladva adódik a megoldás fordított sorrendben.
    public abstract Csúcs Keresés();
    /// <summary>
    /// Kiíratja a megoldást egy terminális csúcs alapján.
    /// Feltételezi, hogy a terminális csúcs szülő referenciáján felfelé haladva eljutunk a start csúcshoz.
    /// A csúcsok sorrendjét megfordítja, hogy helyesen tudja kiírni a megoldást.
    /// Ha a csúcs null, akkor kiírja, hogy nincs megoldás.
    /// </summary>
    /// <param name="egyTerminálisCsúcs">
    /// A megoldást képviselő terminális csúcs vagy null.
    /// </param>
    public void megoldásKiírása(Csúcs egyTerminálisCsúcs)
    {
        if (egyTerminálisCsúcs == null)
        {
            Console.WriteLine("Nincs megoldás");
            return;
        }
        // Meg kell fordítani a csúcsok sorrendjét.
        Stack<Csúcs> megoldás = new Stack<Csúcs>();
        Csúcs aktCsúcs = egyTerminálisCsúcs;
        while (aktCsúcs != null)
        {
            megoldás.Push(aktCsúcs);
            aktCsúcs = aktCsúcs.GetSzülő();
        }
        // Megfordítottuk, lehet kiírni.
        foreach (Csúcs akt in megoldás) Console.WriteLine(akt);
    }
}
/// <summary>
/// A backtrack gráfkereső algoritmust megvalósító osztály.
/// A három alap backtrack algoritmust egyben tartalmazza. Ezek
/// - az alap backtrack
/// - mélységi korlátos backtrack
/// - emlékezetes backtrack
/// Az ág-korlátos backtrack nincs megvalósítva.
/// </summary>
class BackTrack : GráfKereső
{
    int korlát; // Ha nem nulla, akkor mélységi korlátos kereső.
    bool emlékezetes; // Ha igaz, emlékezetes kereső.
    public BackTrack(Csúcs startCsúcs, int korlát, bool emlékezetes) : base(startCsúcs)
    {
        this.korlát = korlát;
        this.emlékezetes = emlékezetes;
    }
    // nincs mélységi korlát, se emlékezet
    public BackTrack(Csúcs startCsúcs) : this(startCsúcs, 0, false) { }
    // mélységi korlátos kereső
    public BackTrack(Csúcs startCsúcs, int korlát) : this(startCsúcs, korlát, false) { }
    // emlékezetes kereső
    public BackTrack(Csúcs startCsúcs, bool emlékezetes) : this(startCsúcs, 0, emlékezetes) { }
    // A keresés a start csúcsból indul.
    // Egy terminális csúcsot ad vissza. A start csúcsból el lehet jutni ebbe a terminális csúcsba.
    // Ha nincs ilyen, akkor null értéket ad vissza.
    public override Csúcs Keresés() { return Keresés(GetStartCsúcs()); }
    // A kereső algoritmus rekurzív megvalósítása.
    // Mivel rekurzív, ezért a visszalépésnek a "return null" felel meg.
    private Csúcs Keresés(Csúcs aktCsúcs)
    {
        int mélység = aktCsúcs.GetMélység();
        // mélységi korlát vizsgálata
        if (korlát > 0 && mélység >= korlát) return null;
        // emlékezet használata kör kiszűréséhez
        Csúcs aktSzülő = null;
        if (emlékezetes) aktSzülő = aktCsúcs.GetSzülő();
        while (aktSzülő != null)
        {
            // Ellenőrzöm, hogy jártam-e ebben az állapotban. Ha igen, akkor visszalépés.
            if (aktCsúcs.Equals(aktSzülő)) return null;
            // Visszafelé haladás a szülői láncon.
            aktSzülő = aktSzülő.GetSzülő();
        }
        if (aktCsúcs.TerminálisCsúcsE())
        {
            // Megvan a megoldás, vissza kell adni a terminális csúcsot.
            return aktCsúcs;
        }
        // Itt hívogatom az alapoperátorokat a szuper operátoron
        // keresztül. Ha valamelyik alkalmazható, akkor új csúcsot
        // készítek, és meghívom önmagamat rekurzívan.
        for (int i = 0; i < aktCsúcs.OperátorokSzáma(); i++)
        {
            // Elkészítem az új gyermek csúcsot.
            // Ez csak akkor lesz kész, ha alkalmazok rá egy alkalmazható operátort is.
            Csúcs újCsúcs = new Csúcs(aktCsúcs);
            // Kipróbálom az i.dik alapoperátort. Alkalmazható?
            if (újCsúcs.SzuperOperátor(i))
            {
                // Ha igen, rekurzívan meghívni önmagam az új csúcsra.
                // Ha nem null értéket ad vissza, akkor megvan a megoldás.
                // Ha null értéket, akkor ki kell próbálni a következő alapoperátort.
                Csúcs terminális = Keresés(újCsúcs);
                if (terminális != null)
                {
                    // Visszaadom a megoldást képviselő terminális csúcsot.
                    return terminális;
                }
                // Az else ágon kellene visszavonni az operátort.
                // Erre akkor van szükség, ha az új gyermeket létrehozásában nem lenne klónozást.
                // Mivel klónoztam, ezért ez a rész üres.
            }
        }
        // Ha kipróbáltam az összes operátort és egyik se vezetett megoldásra, akkor visszalépés.
        // A visszalépés hatására eggyel feljebb a következő alapoperátor kerül sorra.
        return null;
    }
}
/// <summary>
/// Mélységi keresést megvalósító gráfkereső osztály.
/// Ez a megvalósítása a mélységi keresésnek felteszi, hogy a start csúcs nem terminális csúcs.
/// A nyílt csúcsokat veremben tárolja.
/// </summary>
class MélységiKeresés : GráfKereső
{
    // Mélységi keresésnél érdemes a nyílt csúcsokat veremben tárolni,
    // mert így mindig a legnagyobb mélységű csúcs lesz a verem tetején.
    // Így nem kell külön keresni a legnagyobb mélységű nyílt csúcsot, amit ki kell terjeszteni.
    Stack<Csúcs> Nyilt; // Nílt csúcsok halmaza.
    List<Csúcs> Zárt; // Zárt csúcsok halmaza.
    bool körFigyelés; // Ha hamis, végtelen ciklusba eshet.
    public MélységiKeresés(Csúcs startCsúcs, bool körFigyelés) :
    base(startCsúcs)
    {
        Nyilt = new Stack<Csúcs>();
        Nyilt.Push(startCsúcs); // kezdetben csak a start csúcs nyílt
        Zárt = new List<Csúcs>(); // kezdetben a zárt csúcsok halmaza üres
        this.körFigyelés = körFigyelés;
    }
    // A körfigyelés alapértelmezett értéke igaz.
    public MélységiKeresés(Csúcs startCsúcs) : this(startCsúcs, true) { }
    // A megoldás keresés itt indul.
    public override Csúcs Keresés()
    {
        // Ha nem kell körfigyelés, akkor sokkal gyorsabb az algoritmus.
        if (körFigyelés) return TerminálisCsúcsKeresés();
        return TerminálisCsúcsKeresésGyorsan();
    }
    private Csúcs TerminálisCsúcsKeresés()
    {
        // Amíg a nyílt csúcsok halmaza nem nem üres.
        while (Nyilt.Count != 0)
        {
            // Ez a legnagyobb mélységű nyílt csúcs.
            Csúcs C = Nyilt.Pop();
            // Ezt kiterjesztem.
            List<Csúcs> újCsucsok = C.Kiterjesztes();
            foreach (Csúcs D in újCsucsok)
            {
                // Ha megtaláltam a terminális csúcsot, akkor kész vagyok.
                if (D.TerminálisCsúcsE()) return D;
                // Csak azokat az új csúcsokat veszem fel a nyíltak közé,
                // amik nem szerepeltek még sem a zárt, sem a nyílt csúcsok halmazában.
                // A Contains a Csúcs osztályban megírt Equals metódust hívja.
                if (!Zárt.Contains(D) && !Nyilt.Contains(D)) Nyilt.Push(D);
            }
            // A kiterjesztett csúcsot átminősítem zárttá.
            Zárt.Add(C);
        }
        return null;
    }
    // Ezt csak akkor szabad használni, ha biztos, hogy az állapottér gráfban nincs kör!
    // Különben valószínűleg végtelen ciklust okoz.
    private Csúcs TerminálisCsúcsKeresésGyorsan()
    {
        while (Nyilt.Count != 0)
        {
            Csúcs C = Nyilt.Pop();
            List<Csúcs> ujCsucsok = C.Kiterjesztes();
            foreach (Csúcs D in ujCsucsok)
            {
                if (D.TerminálisCsúcsE()) return D;
                // Ha nincs kör, akkor felesleges megnézni, hogy D volt-e már nyíltak vagy a zártak közt.
                Nyilt.Push(D);
            }
            // Ha nincs kör, akkor felesleges C-t zárttá minősíteni.
        }
        return null;
    }
}
class Program
{
    static void Main(string[] args)
    {
        //Csúcs startCsúcs;
        //GráfKereső kereső;
        //Console.WriteLine("A Feladat 1.6 megoldása:");
        //startCsúcs = new Csúcs(new F1p6Állapot());
        //Console.WriteLine("A kereső egy 10 mélységi korlátos és körfigyelés backtrack.");
        //kereső = new BackTrack(startCsúcs, 40, false);
        //kereső.megoldásKiírása(kereső.Keresés());
        //Console.ReadLine();


        Csúcs startCsúcs;
        GráfKereső kereső;
        Console.WriteLine("A Feladat 2.18 megoldása:");
        startCsúcs = new Csúcs(new F2p18Állapot());
        Console.WriteLine("A kereső egy 10 mélységi korlátos és körfigyelés backtrack.");
        kereső = new BackTrack(startCsúcs, 1, false);
        kereső.megoldásKiírása(kereső.Keresés());
        Console.ReadLine();
    }
}