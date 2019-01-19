// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
// *.txt files are not loaded automatically by TurboHUD
// you have to change this file's extension to .cs to enable it
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

using Turbo.Plugins.Default;

namespace Turbo.Plugins.User
{

    public class PluginEnablerOrDisablerPlugin : BasePlugin, ICustomizer
    {

        public PluginEnablerOrDisablerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        // "Customize" methods are automatically executed after every plugin is loaded.
        // So these methods can use Hud.GetPlugin<class> to access the plugin instances' public properties (like decorators, Enabled flag, parameters, etc)
        // Make sure you test the return value against null!
        public void Customize()
        {
			// AriadnesThreadPlugin Customization
               Hud.RunOnPlugin<Resu.AriadnesThreadPlugin>(plugin => 
            { 
               
				plugin.ThreadBetweenPlayers = false; // Set to false to disable the thread between players.
				plugin.Pools = true; // Set to true to enable pools of reflection.
				plugin.BannerTimeSeconds = 3; // Number of seconds you want each player's banner to stay.
				plugin.MetricSystem = false; // Set to true to use metric system for bounty distance.
            });  
			// End of AriadnesThreadPlugin Customization
			// DeluxeShrineLabelsPlugin Customization
               Hud.RunOnPlugin<Resu.DeluxeShrineLabelsPlugin>(plugin =>      
          {
                //Enable permanent Healing Well display
                plugin.ShowHealingWells = false;

                //Enable permanent Pool of reflection display
                plugin.ShowPoolOfReflection = true;

                // Disable displaying Healing Wells & Pools of reflection only when health is under 40%
				plugin.ShowAllWhenHealthIsUnder40 = false;
		
                //Change Pylon Short Name Example
                plugin.ShrineCustomNamesShort[ShrineType.BanditShrine] = "**BANDIT**";

                //Change Pylon Minimap Name Example
                plugin.ShrineCustomNames[ShrineType.BanditShrine] = "OMG A BANDIT SHRINE";

                //Change Pylon Minimap Decorator Example
                //CreateMapDecorators(Font Size, Saturation(0-255), Red(0-255), Green(0-255), Blue(0-255), Radius Offset)
                plugin.ShrineDecorators[ShrineType.BanditShrine] = plugin.CreateMapDecorators(8,255,255,0,0,5);

                //Change Pylon Ground Label Decorator Example
                //CreateGroundLabelDecorators(Font Size, Saturation(0-255), Red(0-255), Green(0-255), Blue(0-255), Bg Saturation(0-255), Bg Red(0-255), Bg Green(0-255), Bg Blue(0-255) )
                plugin.ShrineShortDecorators[ShrineType.BanditShrine] = plugin.CreateGroundLabelDecorators(8,255,255,0,0,255,0,0,0);
            }); 
			// End of DeluxeShrineLabelsPlugin Customization
			// Settings for Paragon Percentage Plugin
               Hud.RunOnPlugin<Resu.ParagonPercentagePlugin>(plugin => 
            { 
                plugin.ParagonPercentageOnTheRight = true; // set to true to display % on the left 
				plugin.ShowGreaterRiftMaxLevel = true; // set to true to disable GR level display
				plugin.DisplayParagonPercentage = true; // set to false to disable paragon percentage display
            });  
			// End of settings for Paragon Percentage Plugin

			// Disable Top Experience Statistics
                           Hud.TogglePlugin<TopExperienceStatistics>(true); 
			// End of Disable Top Experience Statistics

        }

    }

}