import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/auth/login.screen.dart';
import 'package:scratch_collect/modules/auth/signup.screen.dart';
import 'package:scratch_collect/modules/home/details.screen.dart';
import 'package:scratch_collect/modules/home/home.screen.dart';
import 'package:scratch_collect/modules/items/items.screen.dart';
import 'package:scratch_collect/modules/items/play.screen.dart';
import 'package:scratch_collect/modules/profile/change_password.screen.dart';
import 'package:scratch_collect/modules/profile/profile.screen.dart';
import 'package:scratch_collect/modules/profile/profile_edit.screen.dart';
import 'package:scratch_collect/modules/wallet/wallet_options.screen.dart';
import 'package:scratch_collect/modules/wallet/wallet_options_buy.screen.dart';
import 'package:scratch_collect/modules/wallet/wallet_voucher.screen.dart';
import 'package:scratch_collect/modules/winnings/winnings.screen.dart';

final Map<String, WidgetBuilder> routes = {
  // TODO: Splash screen
  // Auth
  LoginScreen.routeName: (context) => const LoginScreen(),
  SignupScreen.routeName: (context) => const SignupScreen(),
  // Home / Offers
  HomeScreen.routeName: (context) => const HomeScreen(),
  DetailsScreen.routeName: (context) => const DetailsScreen(),
  // My items
  ItemsScreen.routeName: (context) => const ItemsScreen(),
  PlayScreen.routeName: (context) => const PlayScreen(),
  // Winnings
  WinningsScreen.routeName: (context) => const WinningsScreen(),
  // Profile
  ProfileScreen.routeName: (context) => const ProfileScreen(),
  ProfileEditScreen.routeName: (context) => const ProfileEditScreen(),
  ChangePasswordScreen.routeName: (context) => const ChangePasswordScreen(),
  // Wallet
  WalletVoucherScreen.routeName: (context) => const WalletVoucherScreen(),
  WalletOptionsScreen.routeName: (context) => const WalletOptionsScreen(),
  WalletOptionsBuyScreen.routeName: (context) => const WalletOptionsBuyScreen()
};
