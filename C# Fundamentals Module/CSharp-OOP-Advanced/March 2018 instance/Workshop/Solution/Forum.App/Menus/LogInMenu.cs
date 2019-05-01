namespace Forum.App.Menus
{
    using Common;
    using Contracts;
    using Models;
    using System;

    public class LogInMenu : Menu
    {
		private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        IForumReader forumReader;

        public LogInMenu(ILabelFactory labelFactory, ICommandFactory commandFactory, IForumReader forumReader)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.forumReader = forumReader;

            this.Open();
        }

        private bool error;
            
        private string UsernameInput => this.Buttons[0].Text.TrimStart();

		private string PasswordInput => this.Buttons[1].Text.TrimStart();

		protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[] { Constants.UserSignDetailsError, "Name:", "Password:" };

            Position[] labelPositions = new Position[]
            {
				new Position(consoleCenter.Left - Constants.UserSignDetailsError.Length / 2, consoleCenter.Top - 13),   // Error: 
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 10),   // Name:
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 8),    // Password:
            };

            this.Labels = new ILabel[labelContents.Length];

            this.Labels[0] = new Label(labelContents[0], labelPositions[0], !this.error);

            for (int i = 1; i < this.Labels.Length; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }

		protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[]
            {
                " ", " ", "Log In", "Back"
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 10, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left - 6, consoleCenter.Top - 8),   // Password
                new Position(consoleCenter.Left + 16, consoleCenter.Top),      // Log In
                new Position(consoleCenter.Left + 16, consoleCenter.Top + 1)   // Back
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
				string buttonContent = buttonContents[i];
				bool isField = string.IsNullOrWhiteSpace(buttonContent);
				this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
            }
        }

		public override IMenu ExecuteCommand()
		{
            if (this.CurrentOption.IsField)
            {
                var left = this.CurrentOption.Position.Left + 1;
                var top = this.CurrentOption.Position.Top;

                var fieldInput = " " + this.forumReader.ReadLine(left, top);

                this.Buttons[this.currentIndex] = this.labelFactory
                    .CreateButton(fieldInput, this.CurrentOption.Position, this.CurrentOption.IsHidden, this.CurrentOption.IsField);

                return this;
            }

            try
            {
                var commandName = string.Join(string.Empty, this.CurrentOption.Text.Split());

                var command = this.commandFactory.CreateCommand(commandName);

                var view = command.Execute(this.UsernameInput, this.PasswordInput);

                return view;
            }
            catch (Exception)
            {
                this.error = true;
                this.Open();
                return this;
            }
        }
	}
}
