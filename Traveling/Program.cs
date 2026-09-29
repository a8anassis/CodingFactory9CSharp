namespace Traveling
{
    /// <summary>
    /// Reads fuel consumption (liters/100 km) and distance (km) from the user, 
    /// calculates the total fuel needed for the trip and the total cost, and 
    /// prints the result formatted to 2 decimal places.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Δήλωση και αρχικοποίηση μεταβλητών
            const double FUEL_PRICE = 1.85;    // Example fuel price

            //double consumption      = 0.0;    // Fuel consumption in liters per 100 km
            //double distance         = 0.0;    // Distance in km
            double litersNeeded;                // Total liters needed for the trip
            double totalCost;                   // Total cost of the fuel for the trip

            // Εισαγωγή δεδομένων, data binding και validation
            Console.WriteLine("Δώστε κατανάλωση (λίτρα/100km)");
            if (!double.TryParse(Console.ReadLine(), out double consumption) || consumption <= 0)
            {
                Console.WriteLine("Μη έγκυρη είσοδος για την κατανάλωση.");
                return;
            }

            Console.WriteLine("Δώστε απόσταση (km)");
            if (!double.TryParse(Console.ReadLine(), out double distance) || distance <= 0)
            {
                Console.WriteLine("Μη έγκυρη είσοδος για την απόσταση.");
                return;
            }

            // Μετατροπή και υπολογισμοί - Λογική του προγράμματος
            litersNeeded = Math.Round(consumption / 100 * distance, 2); // Calculate total liters needed
            totalCost = Math.Round(litersNeeded * FUEL_PRICE, 2); // Calculate total cost

            // Εμφάνιση αποτελεσμάτων
            Console.WriteLine($"{"Κατανάλωση:",-25} {consumption:N2}");
            Console.WriteLine($"{"Απόσταση:",-25} {distance:N2}");
            Console.WriteLine($"{"Τιμή Καυσίμου:",-25} {FUEL_PRICE:N2}");
            Console.WriteLine($"{"Λίτρα που χρειάζονται:",-25} {litersNeeded:N2}");
            Console.WriteLine($"{"Συνολικό Κόστος:",-25} {totalCost:N2}");
        }
    }
}
