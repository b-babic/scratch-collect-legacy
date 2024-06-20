import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:IB210370/modules/home/home.screen.dart';
import 'package:IB210370/modules/items/items.screen.dart';
import 'package:IB210370/modules/profile/profile.screen.dart';
import 'package:IB210370/modules/shared/enums.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/winnings/winnings.screen.dart';

class BottomNavigation extends StatelessWidget {
  const BottomNavigation({super.key, required this.selectedMenu});

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
        child: Column(mainAxisSize: MainAxisSize.min, children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: [
              // Home screen / Offers
              Column(
                children: [
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
                  Text(
                    'Offers',
                    style: TextStyle(
                      fontSize: 14,
                      fontWeight: FontWeight.w700,
                      color: MenuState.offers == selectedMenu
                          ? primaryColor
                          : tertiaryColor,
                    ),
                  ),
                ],
              ),
              // My items screen
              Column(
                children: [
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
                  Text(
                    'My items',
                    style: TextStyle(
                      fontSize: 14,
                      fontWeight: FontWeight.w700,
                      color: MenuState.items == selectedMenu
                          ? primaryColor
                          : tertiaryColor,
                    ),
                  ),
                ],
              ),
              // Winnings screen
              Column(
                children: [
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
                  Text(
                    'Winnings',
                    style: TextStyle(
                      fontSize: 14,
                      fontWeight: FontWeight.w700,
                      color: MenuState.winnings == selectedMenu
                          ? primaryColor
                          : tertiaryColor,
                    ),
                  ),
                ],
              ),
              // Profile screen
              Column(
                children: [
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
                  Text(
                    'Profile',
                    style: TextStyle(
                      fontSize: 14,
                      fontWeight: FontWeight.w700,
                      color: MenuState.profile == selectedMenu
                          ? primaryColor
                          : tertiaryColor,
                    ),
                  ),
                ],
              ),
            ],
          )
        ]));
  }
}
