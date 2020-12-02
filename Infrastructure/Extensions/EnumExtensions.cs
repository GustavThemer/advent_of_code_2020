using EenilasService.Contracts.Enum;

namespace Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static string Translate(this GrammarEnum grammarEnum) =>
            grammarEnum switch
            {
                var grammar when grammar is GrammarEnum.Adjective => "Adjektiv",
                var grammar when grammar is GrammarEnum.Adverb => "Adverb",
                var grammar when grammar is GrammarEnum.AskingAdverb => "Frågeadverb",
                var grammar when grammar is GrammarEnum.Conjunction => "Konjuktion",
                var grammar when grammar is GrammarEnum.Interjection => "Adjektiv",
                var grammar when grammar is GrammarEnum.Noun => "Substantiv",
                var grammar when grammar is GrammarEnum.Numerals => "Räkneord",
                var grammar when grammar is GrammarEnum.PlacementAdverb => "Placeringsadverb",
                var grammar when grammar is GrammarEnum.Preposition => "Preposition",
                var grammar when grammar is GrammarEnum.RoomAdverb => "Rumsadverbial",
                var grammar when grammar is GrammarEnum.TimeAdverb => "Tidsadverbial",
                _ => grammarEnum.ToString()
            };
    }
}