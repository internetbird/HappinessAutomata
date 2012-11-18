using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    /// <summary>
    /// Represents a single human
    /// </summary>
    public class Human
    {
        private Sex m_sex;
        private int m_character;

        private const int MinCharacterValue = 0;
        private const int MaxCharacterValue = 100;

        /// <summary>
        /// Gets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public Sex Sex
        {
            get
            {
                return m_sex;
            }
        }

        /// <summary>
        /// Gets the character.
        /// </summary>
        /// <value>
        /// The character.
        /// </value>
        public int Character
        {
            get
            {
                return m_character;
            }
        }

        public int BestCharacterDiffMemory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Human" /> class.
        /// </summary>
        /// <param name="sex">The sex.</param>
        /// <param name="character">The character.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">character</exception>
        public Human(Sex sex, int character, int bestCharacterDiffMemory)
        {
            if (character < MinCharacterValue || character > MaxCharacterValue)
            {
                throw new ArgumentOutOfRangeException("character");
            }

            m_sex = sex;
            m_character = character;
            BestCharacterDiffMemory = bestCharacterDiffMemory;
        }

        public Human(Sex sex, int character) : this(sex, character, BoardManager.MaxCharacterValue)
        {
        }

    }

    public enum Sex
    {
        Male,
        Female
    }
}
