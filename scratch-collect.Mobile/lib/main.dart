import 'package:IB210370/modules/auth/login.screen.dart';
import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/routes.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Scratch & Collect',
      theme: ThemeData(
        appBarTheme: const AppBarTheme(color: primaryColor),
        pageTransitionsTheme: const PageTransitionsTheme(
          builders: {
            TargetPlatform.android: CupertinoPageTransitionsBuilder(),
            TargetPlatform.iOS: CupertinoPageTransitionsBuilder()
          },
        ),
      ),
      initialRoute: LoginScreen.routeName,
      routes: routes,
    );
  }
}
