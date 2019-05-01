namespace Forum.App.Menus
{
	using System.Collections.Generic;

	using Models;
	using Contracts;
    using Forum.App.Common;

    public class AddReplyMenu : Menu, ITextAreaMenu, IIdHoldingMenu
    {
		private const int authorOffset = 8;
		private const int leftOffset = 18;
		private const int topOffset = 7;
		private const int buttonOffset = 14;

		private ILabelFactory labelFactory;
		private ITextAreaFactory textAreaFactory;
		private IForumReader reader;
        private ICommandFactory commandFactory;

		private bool error;
        private int postId;

        public AddReplyMenu(
            ILabelFactory labelFactory,
            ITextAreaFactory textAreaFactory,
            IForumReader reader,
            ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.textAreaFactory = textAreaFactory;
            this.reader = reader;
            this.commandFactory = commandFactory;

            this.InitializeTextArea();
            this.Open();
        }
        
		public ITextInputArea TextArea { get; private set; }
        
		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			Position errorPosition = 
				new Position(consoleCenter.Left, consoleCenter.Top - 12);

			var labels = new List<ILabel>()
			{
				this.labelFactory.CreateLabel("Cannot add an empty reply!", errorPosition, !error)
			};

			int leftPosition = consoleCenter.Left - leftOffset;
            
			this.Labels = labels.ToArray();
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
            string[] buttonContents = new string[] { "Write", "Reply", "Back" };
            Position[] fieldPositions = new Position[]
            {
               // new Position(consoleCenter.Left - 10, consoleCenter.Top - 12), // Content : 
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left + 14, consoleCenter.Top - 8),  // Write
                new Position(consoleCenter.Left + 14, consoleCenter.Top + 8),  // Reply
                new Position (consoleCenter.Left + 14, consoleCenter.Top + 12) // Back
            };

            this.Buttons = new IButton[fieldPositions.Length + buttonPositions.Length];

            for (int i = 0; i < fieldPositions.Length; i++)
            {
                this.Buttons[i] = this.labelFactory.CreateButton(" ", fieldPositions[i], false, true);
            }

            for (int i = 0; i < buttonPositions.Length; i++)
            {
                this.Buttons[i + fieldPositions.Length] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
            }

            this.TextArea.Render();
        }

		private void InitializeTextArea()
		{
			Position consoleCenter = Position.ConsoleCenter();

			int top = consoleCenter.Top + 5;

			this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, top, false);
		}

		public void SetId(int id)
		{
            this.postId = id;

            this.Open();
        }

        public override IMenu ExecuteCommand()
		{
            if (this.CurrentOption.IsField)
            {
                var left = this.CurrentOption.Position.Left + 1;
                var top = this.CurrentOption.Position.Top;

                var fieldInput = " " + this.reader.ReadLine(left, top);

                this.Buttons[this.currentIndex] = this.labelFactory
                    .CreateButton(fieldInput, this.CurrentOption.Position, this.CurrentOption.IsHidden, this.CurrentOption.IsField);

                return this;
            }

            try
            {
                var commandName = string.Join(string.Empty, this.CurrentOption.Text.Split());

                var command = this.commandFactory.CreateCommand(commandName);
                
                var view = command.Execute(this.postId.ToString(), this.TextArea.Text);

                return view;
            }
            catch
            {
                this.error = true;
                this.InitializeStaticLabels(Position.ConsoleCenter());
                return this;
            }
        }
	}
}
