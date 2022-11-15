using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AoC.Solutions.Y2015
{
    public class D12 : AoCPuzzle
    {
        public D12() : base(2015, 12)
        { }


        public override object SolvePuzzleA(string input)
        {
            int sum = 0;
            JsonNode? jsonNode = JsonNode.Parse(input);
            ResolveJson(jsonNode, ref sum, false);
            return sum;
        }
        public override object SolvePuzzleB(string input)
        {
            int sum = 0;
            JsonNode? jsonNode = JsonNode.Parse(input);
            ResolveJson(jsonNode, ref sum, true);
            return sum;
        }

        private static void ResolveJson(JsonNode? node, ref int sum, bool handleRed)
        {
            switch (node.GetType().Name)
            {
                case nameof(JsonArray):
                    {
                        foreach (JsonNode? jNode in node.AsArray())
                        {
                            switch (jNode)
                            {
                                case JsonObject or JsonArray:


                                    ResolveJson(jNode, ref sum, handleRed);
                                    break;
                                case JsonValue jVal:
                                    {
                                        if (jVal.TryGetValue(out int value))
                                        {
                                            sum += value;
                                        }

                                        break;
                                    }
                            }
                        }

                        break;
                    }
                case nameof(JsonObject):
                    {
                        if (handleRed)
                        {
                            if (node.AsObject().Any(x =>
                                    x.Value is JsonValue val && val.TryGetValue(out string? warn) && warn == "red"))
                                return;
                        }

                        foreach (KeyValuePair<string, JsonNode?> jKvp in node.AsObject())
                        {
                            switch (jKvp.Value)
                            {
                                case JsonObject or JsonArray:
                                    ResolveJson(jKvp.Value, ref sum, handleRed);
                                    break;
                                case JsonValue jVal:
                                    {
                                        if (jVal.TryGetValue(out string? stValue) && handleRed)
                                        {
                                            if (stValue == "red")
                                            {
                                                return;
                                            }
                                        }

                                        if (jVal.TryGetValue(out int value))
                                        {
                                            sum += value;
                                        }

                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }
    }
}