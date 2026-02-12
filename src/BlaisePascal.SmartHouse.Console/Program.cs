
using BlaisePascal.SmartHouse.Domain.Appliances;
using BlaisePascal.SmartHouse.Domain.CCTV;
using BlaisePascal.SmartHouse.Domain.Fixutures;
using BlaisePascal.SmartHouse.Domain.Lighting;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain;



namespace BlaisePascal.SmartHouse
{
    // L'Enum lo mettiamo qui così è visibile a tutto il namespace
    public enum Brand { Samsung, Philips, Nespresso, Dyson, Generic }

    class Program
    {
        static void Main(string[] args)
        {
         
            CoffeeMachine macchinetta = new CoffeeMachine();
            CCTV telecamera = new CCTV("Ingresso");
            Door portaPrincipale = new Door();
            AirConditioner clima = new AirConditioner("Dyson", 1500);
            Lamp luceLed = new Lamp(Brand.Philips, "LED", 8.5, 806, true, "E27");

            bool chiudiApp = false;

            while (!chiudiApp)
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("          SMART HOUSE - PANNELLO LIVE         ");
                Console.WriteLine("==============================================");
                Console.WriteLine("Seleziona COSA vuoi gestire (numero):");
                Console.WriteLine("1. Macchina del Caffè");
                Console.WriteLine("2. Telecamera di Sicurezza");
                Console.WriteLine("3. Porta d'Ingresso");
                Console.WriteLine("4. Climatizzatore");
                Console.WriteLine("5. Illuminazione Soggiorno");
                Console.WriteLine("0. ESCI");
                Console.WriteLine("----------------------------------------------");
                Console.Write("Scelta: ");

                string sceltaPrincipale = Console.ReadLine();

                switch (sceltaPrincipale)
                {
                    case "1": GestisciCaffe(macchinetta); break;
                    case "2": GestisciCCTV(telecamera); break;
                    case "3": GestisciPorta(portaPrincipale); break;
                    case "4": GestisciClima(clima); break;
                    case "5": GestisciLuce(luceLed); break;
                    case "0": chiudiApp = true; break;
                    default:
                        Console.WriteLine("Scelta non valida. Premi un tasto.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GestisciCaffe(CoffeeMachine m)
        {
            bool tornaIndietro = false;
            while (!tornaIndietro)
            {
                Console.Clear();
                Console.WriteLine("--- GESTIONE MACCHINA CAFFÈ ---");
                Console.WriteLine($"Stato: {(m.IsOn ? "ACCESA" : "SPENTA")} | Acqua: {m.WaterLevel}%");
                Console.WriteLine("\n[A] Accendi/Spegni | [B] +Acqua | [C] Tazza | [D] Caffè | [R] Esci");
                Console.Write("\nAzione: ");
                string azione = Console.ReadLine().ToUpper();
                try
                {
                    if (azione == "A") m.TurnOnOrOff();
                    else if (azione == "B") m.AddWater(20);
                    else if (azione == "C") m.PlaceCup();
                    else if (azione == "D") { m.MakeCoffee(); Console.WriteLine("Fatto!"); Console.ReadKey(); }
                    else if (azione == "R") tornaIndietro = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void GestisciCCTV(CCTV c)
        {
            bool torna = false;
            while (!torna)
            {
                Console.Clear();
                Console.WriteLine($"--- CCTV: {c.Name} --- Status: {c.Status}");
                Console.WriteLine("[A] On/Off | [B] Rec | [C] Stop | [R] Esci");
                string azione = Console.ReadLine().ToUpper();
                if (azione == "A") c.TurnOnOrOff();
                else if (azione == "B") c.StartRecording();
                else if (azione == "C") c.StopRecording();
                else if (azione == "R") torna = true;
            }
        }

        static void GestisciPorta(Door d)
        {
            bool torna = false;
            while (!torna)
            {
                Console.Clear();
                Console.WriteLine($"--- PORTA --- Aperta: {d.isOpen} | Bloccata: {d.isLocked}");
                Console.WriteLine("[A] Apri/Chiudi | [B] Lock/Unlock | [R] Esci");
                string azione = Console.ReadLine().ToUpper();
                try
                {
                    if (azione == "A") d.OpenOrClose();
                    else if (azione == "B") d.LockOrUnlock();
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void GestisciClima(AirConditioner ac)
        {
            bool torna = false;
            while (!torna)
            {
                Console.Clear();
                Console.WriteLine($"--- CLIMA {ac.Brand} --- Temp: {ac.TargetTemperature}°");
                Console.WriteLine("[A] On/Off | [B] Imposta Temp | [R] Esci");
                string azione = Console.ReadLine().ToUpper();
                try
                {
                    if (azione == "A") ac.TurnOnOrOff();
                    else if (azione == "B") { Console.Write("Gradi: "); ac.SetTemperature(double.Parse(Console.ReadLine())); }
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void GestisciLuce(Lamp l)
        {
            bool torna = false;
            while (!torna)
            {
                Console.Clear();
                Console.WriteLine($"--- LUCI --- Stato: {(l.IsOn ? "ON" : "OFF")}");
                Console.WriteLine("[A] On/Off | [B] Dimmer | [R] Esci");
                string azione = Console.ReadLine().ToUpper();
                try
                {
                    if (azione == "A") l.TurnOnOrOff();
                    else if (azione == "B") { Console.Write("%: "); l.DimmableControl(double.Parse(Console.ReadLine())); }
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void MostraErrore(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERRORE]: {msg}");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}