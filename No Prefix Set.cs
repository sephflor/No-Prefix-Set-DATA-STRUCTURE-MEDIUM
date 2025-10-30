using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'noPrefix' function below.
     *
     * The function accepts STRING_ARRAY words as parameter.
     */

    public static void noPrefix(List<string> words)
    {
        Trie trie = new Trie();
        
        foreach (string word in words) {
            if (trie.InsertAndCheckPrefix(word)) {
                Console.WriteLine("BAD SET");
                Console.WriteLine(word);
                return;
            }
        }
        
        Console.WriteLine("GOOD SET");
    }
    
    public class TrieNode {
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }
        
        public TrieNode() {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
    }
    
    public class Trie {
        private TrieNode root;
        
        public Trie() {
            root = new TrieNode();
        }
        
        public bool InsertAndCheckPrefix(string word) {
            TrieNode current = root;
            bool prefixFound = false;
            
            foreach (char c in word) {
                if (!current.Children.ContainsKey(c)) {
                    current.Children[c] = new TrieNode();
                } else {
                    // If we're following an existing path and reach end of another word
                    if (current.Children[c].IsEndOfWord) {
                        prefixFound = true;
                    }
                }
                
                current = current.Children[c];
                
                // If current node is end of a word, then this word is a prefix of our current word
                if (current.IsEndOfWord) {
                    prefixFound = true;
                }
            }
            
            // If current node has children, then our current word is a prefix of some other word
            if (current.Children.Count > 0) {
                prefixFound = true;
            }
            
            current.IsEndOfWord = true;
            return prefixFound;
        }
    }

    }

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> words = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string wordsItem = Console.ReadLine();
            words.Add(wordsItem);
        }

        Result.noPrefix(words);
    }
}
