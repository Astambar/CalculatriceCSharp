/**
 * MVP Directive : (Addition , Soustraction , Multiplication , Division, Input Utilisateur, Traitement input utilisateur)
 */

string? InputUser(string message = "Default Message")
{
    Console.WriteLine(message);
    return Console.ReadLine();
}

bool IsOperator(string character)
{
    List<string> operator_list = new List<string> { "*", "/", "-", "+", "%" };
    return operator_list.Contains(character);
}


string? OperatorStrictInput(string? input = null)
{

    if (IsOperator(input))
    {
        return input;
    }
    else
    {
        Console.WriteLine("Ceci n'est pas un opérateur reconnu");
        return null;
    }
}

double? CalculateNumber(double? nombre1, double? nombre2, string? op)
{
    switch (op)
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
{
    return request == "reset" || request == "clear";
}

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
            Console.Clear();
            Console.WriteLine("La purge a commencé ...");
            nombre1 = null;
            operators = null;
            nombre2 = null;
            resulat = null;
            input = null;
            continue;
        }

        if (nombre1 == null)
        {
            Console.WriteLine("Renseigne un nombre");
            input = Console.ReadLine();
            if (IsRequestClear(input))
            {
                Console.Clear();
                Console.WriteLine("La purge a commencé ...");
                continue;
            }
            try
            {
                nombre1 = double.Parse(input);
            }
            catch
            {
                Console.WriteLine("Ceci doit être un nombre");
                continue;
            }
        }

        if (operators == null)
        {
            Console.WriteLine("Renseigne un operateur");
            input = Console.ReadLine();
            if (IsRequestClear(input))
            {
                Console.Clear();
                Console.WriteLine("La purge a commencé ...");
                continue;
            }
            else if (IsOperator(input))
            {
            operators = OperatorStrictInput(input);
            }
            else
            {
                Console.WriteLine("Ceci n'est pas un opérateur ");
                continue;
            }

        }

        if (nombre2 == null)
        {
            Console.WriteLine("Renseigne un nombre");
            input = Console.ReadLine();
            if (IsRequestClear(input))
            {
                Console.Clear();
                Console.WriteLine("La purge a commencé ...");
                continue;
            }
            try
            {
                nombre2 = double.Parse(input);
            }
            catch
            {
                Console.WriteLine("Ceci doit être un nombre");
                continue;
            }
        }

        resulat = CalculateNumber(nombre1, nombre2, operators);
        Console.WriteLine($"Voici le résultat : {resulat}");
        operators = null;
        nombre1 = resulat;
        nombre2 = null;

    } while (true);
}

UserCalculatriceDirective();
