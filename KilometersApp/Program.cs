namespace KilometersApp
{
    /// <summary>
    /// Reads a distance in kilometers from the console/user,
    /// converts it to meters, centimeters and miles, and 
    /// prints the result, formatted to 2 decimal places.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Δήλωση και αρχικοποίηση μεταβλητών
            const double METERS_PER_KM  = 1000D;
            const double CM_PER_KM      = 100000D;
            const double MILES_PER_KM   = 0.621371D;

            double kilometers   = 0D;
            double meters       = 0D;
            double centimeters  = 0D;
            double miles        = 0D;

            // Εισαγωγή δεδομένων, data binding και validation
            Console.WriteLine("Δώστε χιλιόμετρα");
            if (!double.TryParse(Console.ReadLine(), out kilometers) || kilometers < 0)
            {
                Console.WriteLine("Μη έγκυρη είσοδος για χιλιόμετρα.");
                return;
            }

            // Μετατροπή και υπολογισμοί - Λογική του προγράμματος
            meters = kilometers * METERS_PER_KM;
            centimeters = kilometers * CM_PER_KM;
            miles = kilometers * MILES_PER_KM;

            // Εμφάνιση αποτελεσμάτων
            Console.WriteLine($"{"Χιλιόμετρα:",-15} {kilometers,-15:N2} km");
            Console.WriteLine($"{"Μέτρα:",-15} {meters,-15:N2} m");
            Console.WriteLine($"{"Εκατοστά:",-15} {centimeters,-15:N2} cm");
            Console.WriteLine($"{"Μίλια:",-15} {miles,-15:N2} mi");
        }
    }
}
