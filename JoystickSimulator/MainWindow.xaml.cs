﻿using System;
using System.Windows;
using JoystickSimulator.Controllers;
using JoystickSimulator.Packets;

namespace JoystickSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        /// <summary>
        /// EventHandlers
        /// </summary>
        private EventHandler joystickChoosed;
        private EventHandler refrsehButtonPressed;
        private EventHandler InputPacketSent;
        /// <summary>
        /// Contrôleurs
        /// </summary>
        private JoystickController joyController;
        private MathController mathController;
        private FileController fileController;

        public MainWindow()
        {
            InitializeComponent();

            //Création des contrôleurs
            joyController = new JoystickController();
            fileController = new FileController();
            mathController = new MathController(fileController.Cm);

            //Abonnement aux énénements
            JoystickChooserControl.JoystickSelectedEvent += new EventHandler(JoystickSelectedHandler);
            JoystickChooserControl.RefreshButttonPressed += new EventHandler(RefreshButtonPressedHandler);
            joyController.InputPacketSent += new EventHandler(InputPacketSentHandler);

            //Binding de la view à la liste de joysticks
            JoystickChooserControl.ControlerListView.ItemsSource = joyController.ConnectedControllers;

            viewerControl.SetSeatPoint(fileController.Cm.Seat);
        }

        /// <summary>
        /// Est appelé quand un joystick est selectionné dans le contrôle JoystickChooser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void JoystickSelectedHandler(object sender, System.EventArgs e) {
            joyController.CurrentJoystick = ((JoystickEventArgs)e).Joystick;
            tabControl.SelectedIndex = 1;
        }

        /// <summary>
        /// Est appelé quand le bouton refresh est pressé dans le contrôle JoystickChooser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RefreshButtonPressedHandler(object sender, System.EventArgs e) {
            joyController.RefreshJoyStickList();
        }

        void InputPacketSentHandler(object sender, System.EventArgs e) {
            //((InputPacketEventArgs)e). ///bla bla calcul position to math controller
            //bla bla send infos to the view
        }
    }
}