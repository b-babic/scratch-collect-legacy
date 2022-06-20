import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:scratch_collect/modules/home/home.screen.dart';
import 'package:scratch_collect/modules/items/items.screen.dart';
import 'package:scratch_collect/modules/profile/profile.screen.dart';
import 'package:scratch_collect/modules/shared/enums.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/winnings/winnings.screen.dart';

class BottomNavigation extends StatelessWidget {
  const BottomNavigation({Key? key, required this.selectedMenu})
      : super(key: key);

  final MenuState selectedMenu;

  @override
  Widget build(BuildContext context) {
    return Container(
        padding: const EdgeInsets.symmetric(vertical: 14),
        decoration: BoxDecoration(
          color: whiteColor,
          boxShadow: [
            BoxShadow(
              offset: const Offset(0, -15),
              blurRadius: 20,
              color: const Color(0xFFDADADA).withOpacity(0.15),
            ),
          ],
          borderRadius: const BorderRadius.only(
            topLeft: Radius.circular(40),
            topRight: Radius.circular(40),
          ),
        ),
        child: SafeArea(
            top: false,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                // Home screen / Offers
                IconButton(
                  icon: SvgPicture.asset(
                    "lib/modules/shared/assets/icons/cart.svg",
                    color: MenuState.offers == selectedMenu
                        ? primaryColor
                        : tertiaryColor,
                  ),
                  onPressed: () =>
                      Navigator.pushNamed(context, HomeScreen.routeName),
                ),
                // My items screen
                IconButton(
                  icon: SvgPicture.asset(
                    "lib/modules/shared/assets/icons/grid.svg",
                    color: MenuState.items == selectedMenu
                        ? primaryColor
                        : tertiaryColor,
                  ),
                  onPressed: () =>
                      Navigator.pushNamed(context, ItemsScreen.routeName),
                ),
                // Winnings screen
                IconButton(
                  icon: SvgPicture.asset(
                    "lib/modules/shared/assets/icons/truck.svg",
                    color: MenuState.winnings == selectedMenu
                        ? primaryColor
                        : tertiaryColor,
                  ),
                  onPressed: () =>
                      Navigator.pushNamed(context, WinningsScreen.routeName),
                ),
                // Profile screen
                IconButton(
                  icon: SvgPicture.asset(
                    "lib/modules/shared/assets/icons/user.svg",
                    color: MenuState.profile == selectedMenu
                        ? primaryColor
                        : tertiaryColor,
                  ),
                  onPressed: () =>
                      Navigator.pushNamed(context, ProfileScreen.routeName),
                ),
              ],
            )));
  }
}
