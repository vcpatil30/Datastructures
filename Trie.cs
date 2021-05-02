using System;
using System.Collections.Generic;

namespace Trie
{
    public class TrieNode
    {
        public TrieNode[] Chars = new TrieNode[26];
        public bool EndOfWord {get; set;}

        public void AddWord(string word)
        {
            TrieNode curNode = this;
            TrieNode newNode = null;
            
            foreach(char c in word)
            {
                int i = c-'a';
                if(curNode.Chars[i] == null)
                {
                    newNode = new TrieNode();
                    curNode.Chars[i] = newNode;
                    curNode = newNode;
                }
                else
                {
                    curNode = curNode.Chars[i];
                }
            }
            if(newNode != null)
            {
                newNode.EndOfWord = true;
            }
        }


        public bool FindWord(string word)
        {
            TrieNode curNode = this;
            
            foreach(char c in word)
            {
                int i = c-'a';

                if(curNode.Chars[i] == null)
                    return false;

                curNode = curNode.Chars[i];
            }
            return curNode.EndOfWord;
        }

        public void GetAllPossibleWords(List<string> words)
        {
             this.GetAllPossibleWords("", words);
        }

        public void GetAllPossibleWords(string word, List<string> words)
        {
            if(this.EndOfWord == true && !string.IsNullOrEmpty(word))
            {
                words.Add(word); 
            }

            for(int i=0; i<26; i++)
            {
                if(this.Chars[i] != null)
                {
                    this.Chars[i].GetAllPossibleWords(word+(char)(i+'a'), words);
                }
            }
        }

        public void FindWordsWithPrefix(string prefix, List<string> words)
        {
            TrieNode curNode = this;
            
            foreach(char c in prefix)
            {
                int i = c-'a';
                if(curNode.Chars[i] == null)
                {
                    return;
                }
                
                curNode = curNode.Chars[i];
            }

            curNode.GetAllPossibleWords("", words);
        }
    }

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Node Root = new Node();

    //         Root.AddWord("cap");
    //         Root.AddWord("cat");
    //         Root.AddWord("captain");
    //         Root.AddWord("catter");
    //         Root.AddWord("cating");
    //         Root.AddWord("cut");
    //         Root.AddWord("cutter");
    //         Root.AddWord("cutting");
    //         Root.AddWord("cutan");

    //         List<string> words = new List<string>();
    //          Root.GetAllPossibleWords(words);
    //          Display("", words);

    //         string prefix = "ca";
    //         List<string> sufixes = new List<string>();
    //         Root.FindWordsWithPrefix(prefix, sufixes);
    //         Display(prefix, sufixes);

    //         if(Root.FindWord("capt"))
    //             Console.WriteLine("capt found");
    //         else
    //             Console.WriteLine("capt NOT found");

    //     }

    //     static void Display(string prefix, List<string> words)
    //     {
    //         Console.WriteLine("------------Total Words: {0}", words.Count);
    //         foreach(string word in words)
    //         {
    //             if(string.IsNullOrEmpty(prefix))
    //                 Console.WriteLine(word);
    //             else
    //                 Console.WriteLine(prefix + "-" + word);

    //         }
    //     }
    // }
}
