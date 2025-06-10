using System.Linq;
using System.Reflection.Metadata.Ecma335; // használhatok lambda kifejezést

namespace BeadandoUjra_gyak
{
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

    class Huszar
    {
        public int Sor { get; set; }
        public int Oszlop { get; set; }
        public bool IsVilagos { get; set; }

        public Huszar(int sor, int oszlop, bool isVilagos)
        {
            Sor = sor;
            Oszlop = oszlop;
            IsVilagos = isVilagos;
        }
        
        public Huszar Clone()
        {
            return new Huszar(this.Sor, this.Oszlop, this.IsVilagos);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Huszar masik) return false;
            return Sor == masik.Sor && Oszlop == masik.Oszlop && IsVilagos == masik.IsVilagos;
        }

        public override int GetHashCode()
        {
            return Sor * 3 + Oszlop + (IsVilagos ? 100 : 200);
        }
    }

    class F2p18Állapot : AbsztraktÁllapot
    {
        int[,] sakkTabla = new int[,]
        {
            { 0, 0, 0, },
            { 0, 0, 0, },
            { 0, 0, 0, }
        };

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

        List<Huszar> mostFognakLepni = new List<Huszar>();

        public F2p18Állapot()
        {
            foreach (Huszar huszar in vilagosHuszarok)
            {
                sakkTabla[huszar.Sor, huszar.Oszlop] = 1;
            }
            foreach (Huszar huszar in sotetHuszarok)
            {
                sakkTabla[huszar.Sor, huszar.Oszlop] = 2;
            }
            mostFognakLepni = vilagosHuszarok;
        }

        public override bool CélÁllapotE()
        {
            if (vilagosHuszarok.All(h => h.Sor == 2) && sotetHuszarok.All(h => h.Sor == 0))
            {
                return true;
            }
            return false;

        }

        public override int OperátorokSzáma()
        {
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

        private bool lóLépés(int relSor, int relOszlop)
        {
            foreach (Huszar huszar in mostFognakLepni)
            {
                if (!preLóLépés(huszar, relSor, relOszlop)) continue;

                sakkTabla[huszar.Sor, huszar.Oszlop] = 0;
                huszar.Sor += relSor;
                huszar.Oszlop += relOszlop;
                sakkTabla[huszar.Sor, huszar.Oszlop] = huszar.IsVilagos ? 1 : 2;

                mostFognakLepni = mostFognakLepni == vilagosHuszarok ? sotetHuszarok : vilagosHuszarok;

                return ÁllapotE();
            }

            return false;
        }

        private bool preLóLépés(Huszar huszar, int relSor, int relOszlop)
        {
            int újsor = huszar.Sor + relSor;
            int újOszlop = huszar.Oszlop + relOszlop;
            return újsor >= 0 && újsor < sakkTabla.GetLength(0) &&
                   újOszlop >= 0 && újOszlop < sakkTabla.GetLength(1) &&
                   sakkTabla[újsor, újOszlop] == 0;
        }

        public override bool ÁllapotE()
        {
            return true;
        }

        public override string? ToString()
        {
            string ki = "";
            for (int i = 0; i < sakkTabla.GetLength(0); i++)
            {
                for (int j = 0; j < sakkTabla.GetLength(1); j++)
                {
                    ki += sakkTabla[i, j] + " ";
                }
                ki += "\n";
            }
            return ki;
        }

        public override object Clone()
        {
            F2p18Állapot myClone = new F2p18Állapot();
            myClone.sakkTabla = this.sakkTabla.Clone() as int[,];
            myClone.vilagosHuszarok = this.vilagosHuszarok.Select(h => h.Clone()).ToList();
            myClone.sotetHuszarok = this.sotetHuszarok.Select(h => h.Clone()).ToList();
            if (this.mostFognakLepni == this.vilagosHuszarok)
            {
                myClone.mostFognakLepni = myClone.vilagosHuszarok;
            }
            else
            {
                myClone.mostFognakLepni = myClone.sotetHuszarok;
            }
            return myClone;
        }
    }


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
            Csúcs startCsúcs;
            GráfKereső kereső;
            Console.WriteLine("A Feladat 2.18 megoldása:");
            startCsúcs = new Csúcs(new F2p18Állapot());
            Console.WriteLine("A kereső egy 10 mélységi korlátos és körfigyelés backtrack.");
            kereső = new BackTrack(startCsúcs, 10, true);
            kereső.megoldásKiírása(kereső.Keresés());
            Console.ReadLine();
        }
    }
}
