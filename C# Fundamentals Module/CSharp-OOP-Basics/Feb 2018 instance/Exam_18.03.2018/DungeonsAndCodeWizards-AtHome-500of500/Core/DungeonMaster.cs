namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Common;
    using DungeonsAndCodeWizards.Factories;
    using DungeonsAndCodeWizards.Models.Contracts;
    using DungeonsAndCodeWizards.Models.Implementations.Characters;
    using DungeonsAndCodeWizards.Models.Implementations.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private Stack<Item> pool;
        private IList<Character> party;
        private int survivorRounds;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.pool = new Stack<Item>();
            this.party = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            var name = args[2];

            Character character = this.characterFactory.CreateCharacter(args[0], args[1], args[2]);

            this.party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.pool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            var character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, characterName));
            }

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException(ErrorMessages.NoItemsLeftInThePool);
            }

            var itemToBeTaken = this.pool.Peek();

            character.ReceiveItem(itemToBeTaken);

            this.pool.Pop();

            return $"{characterName} picked up {itemToBeTaken.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, characterName));
            }

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.party.FirstOrDefault(c => c.Name == giverName);
            var reciever = this.party.FirstOrDefault(c => c.Name == receiverName);
            
            if (giver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, giverName));
            }
            if (reciever == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, receiverName));
            }

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, reciever);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.party.FirstOrDefault(c => c.Name == giverName);
            var reciever = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (giver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, giverName));
            }
            if (reciever == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, receiverName));
            }

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, reciever);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var builder = new StringBuilder();

            var orderedCharacters = this.party
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health)
                .ToList();

            orderedCharacters
                .ForEach(c => builder.AppendLine(c.ToString()));

            var result = builder.ToString().TrimEnd();

            return result;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = this.party.FirstOrDefault(c => c.Name == attackerName);
            var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, attackerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, receiverName));
            }

            bool canAttack = attacker
                .GetType()
                .GetInterfaces()
                .Contains(typeof(IAttackable));

            if (!canAttack)
            {
                throw new ArgumentException(string.Format(ErrorMessages.AttackerCannotAttack, attackerName));
            }

            var availableAttacker = (IAttackable)attacker;

            availableAttacker.Attack(receiver);

            var result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ";
            result += $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                result += $"{Environment.NewLine}{receiver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = this.party.FirstOrDefault(c => c.Name == healerName);
            var receiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, healerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, healingReceiverName));
            }

            bool canHeal = healer
                .GetType()
                .GetInterfaces()
                .Contains(typeof(IHealable));

            if (!canHeal)
            {
                throw new ArgumentException(string.Format(ErrorMessages.HealerCannotHeal, healerName));
            }

            var availableHealer = (IHealable)healer;

            availableHealer.Heal(receiver);

            var result = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var builder = new StringBuilder();

            var aliveCharacters = this.party.Where(c => c.IsAlive).ToList();

            if (aliveCharacters.Count <= 1)
            {
                this.survivorRounds++;
            }

            foreach (var character in aliveCharacters)
            {
                var currentLine = $"{character.Name} rests ({character.Health} ";
                character.Rest();
                currentLine += $"=> {character.Health})";

                builder.AppendLine(currentLine);
            }

            var result = builder.ToString().TrimEnd();
            
            return result;
        }

        public bool IsGameOver()
        {
            return this.survivorRounds > 1;
        }
    }
}
