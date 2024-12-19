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
bool IsOperator(char character)
{
    List<char> operator_list = ['*','/','-','+','%'];
    return operator_list.Contains(character);
}
List<string?> SegmentatorStringMathematique(string? inputUser = null)
{
    List<string> inputUserList = new List<string>();
    List<char> inputChar = inputUser.ToList();
    int lenInput = inputChar.Count();
    string tempConstruct = "";
    if (inputChar != null && inputUser.Count() > 0)
    {
        if (IsDigit(inputChar[0]))
        {
            // Start Calcul
            for (int i = 0; i < lenInput; i++)
            {
                if (IsDigit(inputChar[i]))
                {
                    tempConstruct = "";
                    for (; i < lenInput; i++)
                        if (IsDigit(inputChar[i]) || inputChar[i] == ',')
                        {
                            tempConstruct += $"{inputChar[i]}";
                        }
                        else if (inputChar[i] == '.')
                        {
                            Console.WriteLine("utiliser plutôt ',' que '.'");
                        }
                        else
                            break;
                    inputUserList.Add(tempConstruct);
                    i--;
                }
                else if(IsOperator(inputChar[i]))
                    inputUserList.Add($"{inputChar[i]}");
            }

        }
        else
        {
            // Message Erreur
        }
        

    }
        
    return inputUserList;
}
string input = InputUser();
List<string> inputUserList = SegmentatorStringMathematique(input);
foreach(string user in inputUserList)
    Console.WriteLine(user);
