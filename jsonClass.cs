using System;
using System.Collections.Generic;


[Serializable]
public class Grammar
{
    public string Noun;
    public string Verb;
    int counter;
}

[Serializable]
public class RootObject
{
    public List<Grammar> grammar = new List<Grammar>();

    public override string ToString()
    {
        //string s= base.ToString() + grammar.Count + "\n";
        string s = "";
        foreach (var item in grammar)
        {
            //s.Add(item.Verb);
            s += item.Noun + " " + item.Verb + " \n";
            //+ " : " + item.Verb + "\n";
        }
        return s;
    }
    public Grammar getGrammar(int count)
    {
        return grammar[count];
    }
}


