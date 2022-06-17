import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/auth/login.screen.dart';
import 'package:scratch_collect/modules/auth/signup.screen.dart';
import 'package:scratch_collect/modules/home/home.screen.dart';

final Map<String, WidgetBuilder> routes = {
  // TODO: Splash screen
  LoginScreen.routeName: (context) => const LoginScreen(),
  SignupScreen.routeName: (context) => const SignupScreen(),
  HomeScreen.routeName: (context) => const HomeScreen(),
};
