using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;
using System.ComponentModel;

namespace InferenceEngine
{
    class Clause
    {
        public string antecedent;
        public List<string> consequent;

        public Clause()
        {
            antecedent = "";
            consequent = new List<string>();
        }
    }
    class Program
    {
        public static Dictionary<string, bool> bcfacts = new Dictionary<string, bool>();
        static List<Clause> bcrules = new List<Clause>();
        static HashSet<string> bcvisited = new HashSet<string>();
        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            int nclause = int.Parse(firstLine[1]);
            int ngoals = int.Parse(firstLine[2]);
            char searchMethod = char.Parse(firstLine[3]);

            List<Clause> clauses = new List<Clause>();
            List<string> goals = new List<string>();

            // aantal clauses
            for (int i = 0; i < nclause; i++)
            {
                string rawclause = Console.ReadLine();

                if (rawclause.Contains(":-"))
                {
                    // implicatie
                    string[] clause = rawclause.Split(':');
                    string ant = clause[0];
                    string cons = clause[1].Split('%')[0].Trim().Replace(",", "").Replace("-", "");
                    int j = 0;
                    if (!cons.Contains("."))
                    {
                        while (j == 0)
                        {
                            string cons2 = Console.ReadLine().Split('%')[0].Trim().Replace(",", "");
                            if (cons2.Contains("."))
                            {
                                j = 1;
                            }
                            cons = cons + " " + cons2;
                        }

                    }

                    Clause endClause = new Clause();
                    endClause.antecedent = ant.Trim();
                    foreach (string var in cons.Split('.')[0].Trim().Split(' '))
                    {
                        endClause.consequent.Add(var);
                    }
                    clauses.Add(endClause);

                    bcrules.Add(endClause);
                }
                else
                {
                    // fact
                    string fact = rawclause.Split('.')[0];

                    Clause factClause = new Clause();
                    factClause.antecedent = fact;
                    factClause.consequent.Add("true");
                    clauses.Add(factClause);

                    bcfacts.Add(fact, true);
                }
            }
            Clause waar = new Clause();
            waar.antecedent = "true";
            waar.consequent.Add("true");
            clauses.Add(waar);

            // aantal goals
            for (int i = 0; i < ngoals; i++)
            {
                string goal = Console.ReadLine().Split(' ')[1].Replace(".", "");
                goals.Add(goal);
            }

            // Methode checken
            if (searchMethod == 'f')
            {
                Dictionary<Clause, int> count = new Dictionary<Clause, int>();
                Dictionary<string, bool> inferred = new Dictionary<string, bool>();

                foreach (Clause clause in clauses)
                {
                    count[clause] = clause.consequent.Count;
                    //clause.consequent.Split(' ').Length;
                }

                foreach (Clause clause in clauses)
                {
                    try
                    {
                        inferred.Add(clause.antecedent, false);
                    }
                    catch { }
                }

                // Forward chain methode
                for (int i = 0; i < goals.Count; ++i)
                {
                    //Console.WriteLine(goals[i] + ". " + "false.");
                    Console.WriteLine(goals[i] + ". " + ForwardChainingMethod(clauses, goals[i], count.ToDictionary(entry => entry.Key,
                                           entry => entry.Value), inferred.ToDictionary(entry => entry.Key,
                                           entry => entry.Value)).ToString().ToLower() + ".");
                }
            }
            if (searchMethod == 'b')
            {
                // Backward chain methode
                for (int i = 0; i < goals.Count; ++i)
                {
                    //Console.WriteLine(goals[i] + ". " + "false.");
                    Console.WriteLine(goals[i] + ". " + BackwardChainingMethod(goals[i]).ToString().ToLower() + ".");
                }
            }
        }

        public static bool ForwardChainingMethod(List<Clause> KB, string q, Dictionary<Clause, int> count, Dictionary<string, bool> inferred)
        {

            Queue<string> queue = new Queue<string>();

            foreach (Clause clause in KB)
            {
                if (clause.consequent.Contains("true"))
                {
                    queue.Enqueue(clause.antecedent);
                }
            }

            //Console.WriteLine();

            while (queue.Count != 0)
            {
                string p = queue.Dequeue();

                if (p == q) return true;

                if (inferred[p] == false)
                {
                    inferred[p] = true;
                    foreach (Clause clause in KB)
                    {
                        if (clause.consequent.Contains(p))
                        {
                            count[clause] -= 1;
                            if (count[clause] == 0)
                            {
                                if (clause.antecedent == q)
                                    return true;
                                queue.Enqueue(clause.antecedent);
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool BackwardChainingMethod(string query)
        {
            // Check if the query is already a known fact
            if (bcfacts.ContainsKey(query))
            {
                return bcfacts[query];
            }

            // Check if we've already visited this symbol in the current chain
            if (bcvisited.Contains(query))
            {
                return false;
            }

            bcvisited.Add(query);

            // Find rules that conclude the query
            List<Clause> matchingRules = bcrules.Where(rule => rule.antecedent == query).ToList();

            // If no rules conclude the query, it cannot be proved
            if (matchingRules.Count == 0)
            {
                bcvisited.Remove(query);
                return false;
            }

            // Try to prove each premise of the matching rules recursively
            foreach (Clause rule in matchingRules)
            {
                bool ruleIsTrue = true;
                foreach (string premise in rule.consequent)
                {
                    ruleIsTrue = ruleIsTrue && BackwardChainingMethod(premise);
                    // If any premise of the rule is false, move to the next rule
                    if (!ruleIsTrue)
                    {
                        break;
                    }
                }
                if (ruleIsTrue)
                {
                    // All premises of the rule are true, so the conclusion is true
                    bcfacts.Add(query, true);
                    bcvisited.Remove(query);
                    return true;
                }
            }

            bcvisited.Remove(query);

            // None of the rules with the conclusion were true, so the query is false
            return false;
        }
    }
}
