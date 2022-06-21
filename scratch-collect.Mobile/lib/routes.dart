import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/auth/login.screen.dart';
import 'package:scratch_collect/modules/auth/signup.screen.dart';
import 'package:scratch_collect/modules/home/home.screen.dart';
import 'package:scratch_collect/modules/items/items.screen.dart';
import 'package:scratch_collect/modules/profile/profile.screen.dart';
import 'package:scratch_collect/modules/profile/profile_edit.screen.dart';
import 'package:scratch_collect/modules/winnings/winnings.screen.dart';

final Map<String, WidgetBuilder> routes = {
  // TODO: Splash screen
  // Auth
  LoginScreen.routeName: (context) => const LoginScreen(),
  SignupScreen.routeName: (context) => const SignupScreen(),
  // Home / Offers
  HomeScreen.routeName: (context) => const HomeScreen(),
  // My items
  ItemsScreen.routeName: (context) => const ItemsScreen(),
  // Winnings
  WinningsScreen.routeName: (context) => const WinningsScreen(),
  // Profile
  ProfileScreen.routeName: (context) => const ProfileScreen(),
  ProfileEditScreen.routeName: (context) => const ProfileEditScreen()
};
