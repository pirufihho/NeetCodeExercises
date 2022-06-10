// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

int[] nums = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };

ContainsDuplicate(nums);

string s = "anagram", t = "nagaram";
IsAnagram(s, t);

int[] nums2 = { 2,5,5,11 };
int target = 10;

TwoSum(nums2, target);

int[] nums3 = { 2,2, 1,1,1,3,4,4,4,4 };
int k = 2;

TopKFrequent(nums3, k);

int[] myArray = { 13, 2, 4, 35, 1 };

findLargest(myArray);

int[] myArray2 = { 1, 2, 1, 3, 3, 1, 2, 1, 5, 1 };

findOccurrences(myArray2);

//codility 
int[] myArray3 = { 1, 2, 3 };
missingInteger(myArray3);

string str = "__bbbbbbb";
CodelandUsernameValidation(str);

string str2 = "acc?7??sss?3rr1??????5";
QuestionsMarks(str2);

string str3 = "x";
StringChallenge(str3);


string[] str4 = { "4", "0:2", "2:2", "1:1" };
ArrayChallenge(str4);

backendChallenge();


string ArrayChallenge(string[] strArr)
{
    int Gas = 0;
    string result = "";
    for (int startindex = 1; startindex < strArr.Length; startindex++)
    {
        Gas = 0;
        for (int i = startindex; i < strArr.Length; i++)
        {
            var splited = strArr[i].Split(':');
            Gas += Convert.ToInt32(splited[0]) - Convert.ToInt32(splited[1]);
            
        }

        if(Gas==0)
        {
            result = startindex.ToString();
        }
    }

    if (result == "")
    {
        result = "impossible";
    }

    return result;
}

void backendChallenge()
{
    WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");
    WebResponse response = request.GetResponse();
    using (Stream data = response.GetResponseStream())
    {
        StreamReader read = new StreamReader(data);
        string text = read.ReadToEnd();
        dynamic json = JObject.Parse(text);
        RemoveJson(json["name"]);
        RemoveJson(json["age"]);
        RemoveJson(json["DOB"]);
        RemoveJson(json["hobbies"]);
        RemoveJson(json["education"]);
        Console.WriteLine(json);
    }

    response.Close();

}

static void RemoveJson(dynamic node)
{
    bool removed = true;
    while (removed)
    {
        try
        {
            foreach (var item in node)
            {
                if (item.Value.ToString() == "" || item.Value.ToString() == "N/A")
                {
                    item.Remove();
                    removed = true;
                    break;
                }
                if(item.Value.ToString() == "-")
                {
                    item.Remove();
                    removed = true;
                    break;
                }
                else
                    removed = false;
            }
        }
        catch (Exception)
        {
            removed = false;
        }
    }
}

string StringChallenge(string str)
{
    string result = "";
    List<char> arrayX = new List<char>();
    List<char> arrayO = new List<char>();

    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] == 'x')
        {
            arrayX.Add(str[i]);
        }
        if(str[i] == 'o')
        {
            arrayO.Add(str[i]);
        }
    }
    if(arrayX.Count == arrayO.Count)
    {
        result = "true";
    }
    else { result = "false"; }

    // code goes here  
    return result;

}

string QuestionsMarks(string str) {
    string result = "false";
    var indexes = new List<int>();
    for (int i = 0; i < str.Length; i++)
    {
        if (char.IsDigit(str[i]))
        {
            indexes.Add(i);
        }
    }
    for (int i = 0; i < indexes.Count-1; i++)
    {
        if( char.GetNumericValue(str[indexes[i]]) + char.GetNumericValue(str[indexes[i+1]]) == 10)
        {
            //find if there is ??? betwen those 2 indexes
            var substring = str.Substring(indexes[i], indexes[i+1]-indexes[i]);
            var findedQuestion = "";

            for (int j = 0; j < substring.Length; j++)
            {
                if(substring[j] == '?')
                {
                    findedQuestion += '?';
                }

                if (findedQuestion == "???")
                {
                    result = "true";
                    break;
                }
            }     
        }
    }

    // code goes here  
    return result;

}

string CodelandUsernameValidation(string str)
{
    string result = "";

    string first = str[0].ToString();

    if (Regex.IsMatch(first, @"^[a-zA-Z]+$") 
        && Regex.IsMatch(str, @"^[a-zA-Z0-9_]+$") 
        && str[str.Length - 1].ToString() != "_"
        && str.Length >= 4 && str.Length <= 25)
    {
        result = "true";
    }
    else 
    { 
        result = "false"; 
    }

    // code goes here  
        return result;

}

int missingInteger(int[] nums) {
    Array.Sort(nums);
    int longest = nums[nums.Length - 1];
    int shortest = nums[0];
    int result = 0;

    if (longest < 0)
    {
        result = 1;
    }
    else
    {
        for (int i = shortest; i <= longest+1; i++)
        {
            var numberFinded = nums.ToList().Find(x => x == i);
            if (numberFinded == 0)
            {
                result = i;
                break;
            }
        }
    }

    return result;
}

void findOccurrences(int[] array){
    Array.Sort(array);
    //List<int> list = array.ToList();

    int[] numbers = {1,2,3,4,5};

    foreach (var n in numbers)
    {
        string print = n.ToString() + ": ";
        //List<int> ocurrences = list.FindAll(x => x == n);

        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] == n)
            {
                print = print + '*';
            }   
        }
        Console.Write(print);
    }
}

int findLargest(int[] array) {
    Array.Sort(array);
    Console.WriteLine(array[array.Length-1]);

    return 0;    
}

int[] TopKFrequent(int[] nums, int k)
{
    SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
    int[] output = new int[k];;

    for (int i = 0; i < nums.Length; i++)
    {
        var findedNumbers = nums.ToList().Where(x => x == nums[i]);

        if (!dict.ContainsKey(nums[i]))
        {
            dict.Add(nums[i], findedNumbers.Count());
        }
    }

    //order hashtable descending
    var ordered = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

    for (int j = 0; j < k; j++)
    {
        //find first element from dict
        var firstElement = ordered.First().Key;

        //add to output
        output[j] = firstElement;

        //remove from dictionary
        ordered.Remove(firstElement);
    }

    return output.ToArray();
}

bool ContainsDuplicate(int[] nums)
{
    bool isDuplicated = false;
    for (int i = 0; i < nums.Length; i++)
    {
        var cantNumbers = nums.Where(x => x == nums[i]).ToList();
        if(cantNumbers != null && cantNumbers.Count > 1) { isDuplicated = true; break; } 
    }
    Console.WriteLine(isDuplicated);
    return isDuplicated;
}

bool IsAnagram(string s, string t)
{
    char[] chars = s.ToCharArray();
    char[] chars2 = t.ToCharArray();
    Array.Sort(chars);
    Array.Sort(chars2);

    var sString = new string(chars);   
    var tString = new string(chars2);   

    if (sString == tString) {
        return true;
    }
    else { 
        return false; 
    }
    
}

 //wrong me saca el 5 repetido
int[] TwoSum(int[] nums, int target)
{
    int[] output = new int[2] ;
    for (int i = 0; i < nums.Length; i++)
    {
        //var numberA = nums[i] ; 
        //var numberB = nums[i+1] ;   

        //if(numberA + numberB == target)
        //{
        //    output[0] = i;
        //    output[1] = i+1;
        //    return output;
        //}

        var currentNumber = nums[i];
        FindTwo(nums, currentNumber,i, target);

    }
    return output;
}
int[] FindTwo(int[] nums, int currentNumber,int currentIndex, int target)
{
    var numsFiltered = nums;
    numsFiltered.ToList().RemoveAt(currentIndex);
    int[] output = new int[2] ;
    for (int i = 0; i < numsFiltered.Length; i++)
    {
        if(numsFiltered[i] + currentNumber == target)
        {
            output[0] = currentIndex;
            output[1] = nums.ToList().FindIndex(x=> x == numsFiltered[i]);
        }    

    }

    return numsFiltered;
}

Console.ReadLine();
