
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



namespace BlaisePascal.SmartHouse.Console
{
    // L'Enum lo mettiamo qui così è visibile a tutto il namespace
    public enum Brand { Samsung, Philips, Nespresso, Dyson, Generic }

    public class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine macchinetta = new CoffeeMachine();
            CCTV telecamera = new CCTV("Ingresso");
            Door portaPrincipale = new Door();
            AirConditioner clima = new AirConditioner("Dyson", 1500);
            Lamp luceLed = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 8.5, 806, true, "E27");

            bool chiudiApp = false;

            while (!chiudiApp)
            {
                System.Console.Clear();
                System.Console.WriteLine("==============================================");
                System.Console.WriteLine("          SMART HOUSE - PANNELLO LIVE         ");
                System.Console.WriteLine("==============================================");
                System.Console.WriteLine("Seleziona COSA vuoi gestire (numero):");
                System.Console.WriteLine("1. Macchina del Caffè");
                System.Console.WriteLine("2. Telecamera di Sicurezza");
                System.Console.WriteLine("3. Porta d'Ingresso");
                System.Console.WriteLine("4. Climatizzatore");
                System.Console.WriteLine("5. Illuminazione Soggiorno");
                System.Console.WriteLine("0. ESCI");
                System.Console.WriteLine("----------------------------------------------");
                System.Console.WriteLine("Scelta: ");

                // Proteggo contro il valore null di Console.ReadLine()
                string sceltaPrincipale = System.Console.ReadLine() ?? string.Empty;

                switch (sceltaPrincipale)
                {
                    case "1": GestisciCaffe(macchinetta); break;
                    case "2": GestisciCCTV(telecamera); break;
                    case "3": GestisciPorta(portaPrincipale); break;
                    case "4": GestisciClima(clima); break;
                    case "5": GestisciLuce(luceLed); break;
                    case "0": chiudiApp = true; break;
                    default:
                        System.Console.WriteLine("Scelta non valida. Premi un tasto.");
                        System.Console.ReadKey();
                        break;
                }
            }
        }

        static void GestisciCaffe(CoffeeMachine m)
        {
            bool tornaIndietro = false;
            while (!tornaIndietro)
            {
                System.Console.Clear();
                System.Console.WriteLine("--- GESTIONE MACCHINA CAFFÈ ---");
                System.Console.WriteLine($"Stato: {(m.IsOn ? "ACCESA" : "SPENTA")} | Acqua: {m.WaterLevel}%");
                System.Console.WriteLine("\n[A] Accendi/Spegni | [B] +Acqua | [C] Tazza | [D] Caffè | [R] Esci");
                System.Console.Write("\nAzione: ");
                string azione = System.Console.ReadLine().ToUpper();
                try
                {
                    if (azione == "A") m.TurnOnOrOff();
                    else if (azione == "B") m.AddWater(20);
                    else if (azione == "C") m.PlaceCup();
                    else if (azione == "D") { m.MakeCoffee(); System.Console.WriteLine("Fatto!"); System.Console.ReadKey(); }
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
                System.Console.Clear();
                System.Console.WriteLine($"--- CCTV: {c.Name} --- Status: {c.Status}");
                System.Console.WriteLine("[A] On/Off | [B] Rec | [C] Stop | [R] Esci");
                string azione = System.Console.ReadLine().ToUpper();
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
                System. Console.Clear();
                System.Console.WriteLine($"--- PORTA --- Aperta: {d.isOpen} | Bloccata: {d.isLocked}");
                System.Console.WriteLine("[A] Apri/Chiudi | [B] Lock/Unlock | [R] Esci");
                string azione = System.Console.ReadLine().ToUpper();
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
                System.Console.Clear();
                System.Console.WriteLine($"--- CLIMA {ac.Brand} --- Temp: {ac.TargetTemperature}°");
                System.Console.WriteLine("[A] On/Off | [B] Imposta Temp | [R] Esci");
                string azione = System.Console.ReadLine().ToUpper();
                try
                {
                    if (azione == "A") ac.TurnOnOrOff();
                    else if (azione == "B") { System.Console.Write("Gradi: "); ac.SetTemperature(double.Parse(System.Console.ReadLine())); }
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
                System.Console.Clear();
                System.Console.WriteLine($"--- LUCI --- Stato: {(l.IsOn ? "ON" : "OFF")}");
                System.Console.WriteLine("[A] On/Off | [B] Dimmer | [R] Esci");
                string azione = System.Console.ReadLine().ToUpper();
                try
                {
                    if (azione == "A") l.TurnOnOrOff();
                    else if (azione == "B") { System.Console.Write("%: "); l.DimmableControl(double.Parse(System.Console.ReadLine())); }
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void MostraErrore(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"\n[ERRORE]: {msg}");
            System.Console.ResetColor();
            System.Console.ReadKey();
        }
    }
}
