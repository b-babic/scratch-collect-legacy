import 'package:flutter/widgets.dart';
import 'package:ib210370_desktop/modules/auth/login.screen.dart';

import 'modules/home/home.screen.dart';

final Map<String, WidgetBuilder> routes = {
  // Auth
  LoginScreen.routeName: (context) => const LoginScreen(),

  // Home
  HomeScreen.routeName: (context) => const HomeScreen(),
};
