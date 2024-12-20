/**
 * MVP Directive : (Addition , Soustraction , Multiplication , Division, Input Utilisateur, Traitement input utilisateur)
 */

string? InputUser(string message = "Default Message")
{
    Console.WriteLine(message);
    return Console.ReadLine();
}

bool IsDigit(char character)
{
    int characterAsciiFormat = Convert.ToInt32(character);
    return character >= 47 && character <= 57;
}
bool IsOperator(string character)
{
    List<string> operator_list = ["*","/","-","+","%"];
    return operator_list.Contains(character);
}
double NumberStrictInput()
{
    double result = 0;
    do
    {
        try
        {
            result = double.Parse(InputUser("Entre un nombre"));
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("Pas Content");
        }
    }while(true);
    return result;
}
string OperatorStrictInput(string? input = null)
{
    string result;

    do
    {
        result = InputUser("Saisie un opérateur: ");
            if(IsOperator(result))
            { 
                return result;
            }
            else
            {
                Console.WriteLine("Ceci n'est pas un opérateur reconnu");
                continue;
            }
        
    } while (true);
}
double? CalculateNumber(double? nombre1, double? nombre2, string? op)
{
    switch(op)
    {
        case "*":
            return nombre1 * nombre2;
        case "/":
            return nombre1 / nombre2;
        case "-":
            return nombre1 - nombre2;
        case "+":
            return nombre1 + nombre2;
        case "%":
            return nombre1 % nombre2;
        default:
            return null;
    }
}

bool IsRequestClear(string? request)
{ return request == "reset" || request == "clear"; }
void UserCalculatriceDirective()
{
    double? nombre1 = null;
    string? operators = null;
    double? nombre2 = null;
    double? resulat = null;
    string? input = null;
    do
    {
        
        if (IsRequestClear(input))
        {
            nombre1 = null;
            operators = null;
            nombre2 = null;
            resulat = null;
            input = null;
        }
        if (nombre1 == null)
        {
            Console.WriteLine("Renseigne un nombre");
            input = Console.ReadLine();
            if (IsRequestClear(input))
            {
                Console.Clear();
                Console.WriteLine("La purge  à commencer ...");
                continue;
            }
            try
            {
                nombre1 = double.Parse(input);
            }
            catch
            {
                Console.WriteLine("Ceci  doit être un nombre");
                continue;
            }
        }
        if (operators == null)
        { operators = OperatorStrictInput(); }
        if (nombre2 == null)
        {
            Console.WriteLine("Renseigne un nombre");
            input = Console.ReadLine();
            if (IsRequestClear(input))
            {
                Console.Clear();
                Console.WriteLine("La purge  à commencer ...");
                continue;
            }
            try
            {
                nombre2 = double.Parse(input);
            }
            catch
            {
                Console.WriteLine("Ceci  doit être un nombre");
                continue;
            }
        }
        resulat = CalculateNumber(nombre1,nombre2, operators);
        Console.WriteLine($"Voici le résultat : {resulat}");
        operators = null;
        nombre1 = resulat;
        nombre2 = null;
    } while (true);
}
UserCalculatriceDirective();
