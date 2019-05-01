using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private Stack<Item> items;
        private List<Character> characters;
        private CharacterFactory characterFactory;
        private ItemFactory ItemFactory;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.items = new Stack<Item>();
            this.characters = new List<Character>();
            this.characterFactory = new CharacterFactory();
            this.ItemFactory = new ItemFactory();
            this.lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];

            var character = this.characterFactory.CreateCharacter(faction, characterType, name);

            this.characters.Add(character);

            var result = $"{name} joined the party!";

            return result;
        }

        public string AddItemToPool(string[] args)
        {
            var itemType = args[0];

            var item = this.ItemFactory.CreateItem(itemType);

            this.items.Push(item);

            var result = $"{itemType} added to pool.";

            return result;
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            var character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var itemToBePicked = this.items.Pop();

            character.ReceiveItem(itemToBePicked);

            var result = $"{characterName} picked up {itemToBePicked.GetType().Name}!";

            return result;
        }

        public string UseItem(string[] args)
        {
            var charName = args[0];
            var itemName = args[1];

            var character = this.characters
                .FirstOrDefault(c => c.Name == charName)
                ?? throw new ArgumentException($"Character {charName} not found!");

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            var result = $"{charName} used {itemName}.";

            return result;
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.characters
                .FirstOrDefault(c => c.Name == giverName)
                ?? throw new ArgumentException($"Character {giverName} not found!");

            var receiver = this.characters
                .FirstOrDefault(c => c.Name == receiverName)
                ?? throw new ArgumentException($"Character {receiverName} not found!");

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            var result = $"{giverName} used {itemName} on {receiverName}.";

            return result;
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.characters
                .FirstOrDefault(c => c.Name == giverName)
                ?? throw new ArgumentException($"Character {giverName} not found!");

            var receiver = this.characters
                .FirstOrDefault(c => c.Name == receiverName)
                ?? throw new ArgumentException($"Character {receiverName} not found!");

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            var result = $"{giverName} gave {receiverName} {itemName}.";

            return result;
        }

        public string GetStats()
        {
            var builder = new StringBuilder();

            var sortedCharacters = this.characters
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health)
                .ToList();

            sortedCharacters
                .ForEach(c => builder.AppendLine(c.ToString()));

            var result = builder.ToString().TrimEnd();

            return result;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = this.characters
                .FirstOrDefault(c => c.Name == attackerName)
                ?? throw new ArgumentException($"Character {attackerName} not found!");

            var receiver = this.characters
                .FirstOrDefault(c => c.Name == receiverName)
                ?? throw new ArgumentException($"Character {receiverName} not found!"); ;

            if (!typeof(IAttackable).IsAssignableFrom(attacker.GetType()))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var attackable = (IAttackable)attacker;

            attackable.Attack(receiver);

            var result = $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! " +
                $"{receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                result += $"{Environment.NewLine}{receiver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var receiverName = args[1];

            var healer = this.characters
                .FirstOrDefault(c => c.Name == healerName)
                ?? throw new ArgumentException($"Character {healerName} not found!");

            var receiver = this.characters
                .FirstOrDefault(c => c.Name == receiverName)
                ?? throw new ArgumentException($"Character {receiverName} not found!");

            if (!typeof(IHealable).IsAssignableFrom(healer.GetType()))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            var healable = (IHealable)healer;

            healable.Heal(receiver);

            var result = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var builder = new StringBuilder();

            var aliveCharacters = this.characters.Where(c => c.IsAlive).ToList();

            foreach (var character in aliveCharacters)
            {
                var healthBeforeRest = character.Health;

                character.Rest();

                var currentHealth = character.Health;

                builder.AppendLine($"{character.Name} rests ({healthBeforeRest} => {currentHealth})");
            }

            if (aliveCharacters.Count <= 1)
            {
                this.lastSurvivorRounds++;
            }

            var result = builder.ToString().TrimEnd();

            return result;
        }

        public bool IsGameOver() => this.lastSurvivorRounds > 1;

    }
}
