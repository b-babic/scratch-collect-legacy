import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:IB210370/modules/auth/constants.dart';
import 'package:IB210370/modules/auth/services/auth.service.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/utils/keyboard.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/shared/widgets/form_error.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';
import 'package:IB210370/modules/wallet/models/voucher_options_buy_arguments.dart';
import 'package:IB210370/modules/wallet/models/voucher_options_buy_request.dart';
import 'package:IB210370/modules/wallet/services/voucher.service.dart';
import 'package:IB210370/modules/wallet/wallet_voucher.screen.dart';

class BuyVoucherOptionsForm extends StatefulWidget {
  final VoucherOptionsBuyArguments initialValues;

  const BuyVoucherOptionsForm({Key? key, required this.initialValues})
      : super(key: key);

  @override
  BuyVoucherOptionsFormState createState() => BuyVoucherOptionsFormState();
}

class BuyVoucherOptionsFormState extends State<BuyVoucherOptionsForm> {
  final _formKey = GlobalKey<FormState>();

  // Fields
  String? cardNumber;
  String? cvv;
  String? expiryMonth;
  String? expiryYear;

  // Controllers
  late TextEditingController _amountController;

  final List<String?> errors = [];

  @override
  void initState() {
    super.initState();

    _amountController = TextEditingController(
        text: widget.initialValues.item?.amount.toString());
  }

  void addError({String? error}) {
    if (!errors.contains(error)) {
      setState(() {
        errors.add(error);
      });
    }
  }

  void removeError({String? error}) {
    if (errors.contains(error)) {
      setState(() {
        errors.remove(error);
      });
    }
  }

  void clearErrors() {
    setState(() {
      errors.clear();
    });
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Form(
        key: _formKey,
        child: Column(
          children: [
            buildAmountFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildCardNumberFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildCvvFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildExpiryMonthFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildExpiryYearFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            FormError(errors: errors),
            SizedBox(height: getProportionateScreenHeight(60)),
            Button(
                text: "Confirm Payment",
                press: () async {
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();

                    KeyboardUtil.hideKeyboard(context);

                    clearErrors();

                    try {
                      var user = await AuthService().getPersistedUser();

                      var request = VoucherBuyRequest(
                        userId: user.id.toString(),
                        cardNumber: cardNumber,
                        cvv: cvv,
                        expiryDate: "$expiryMonth/$expiryYear",
                        amount: widget.initialValues.item?.amount.toString(),
                      );

                      var updated = await VoucherService().buyOption(request);

                      if (!mounted) return;

                      if (updated.id != null) {
                        Snackbar.showSuccess(
                            context, "Wallet balance updated!");
                        Navigator.pushNamed(
                            context, WalletVoucherScreen.routeName);
                      }
                    } on Exception catch (e) {
                      Snackbar.showError(context, e.toString());
                    }
                  }
                })
          ],
        ));
  }

  // Builders
  TextFormField buildAmountFormField() {
    return TextFormField(
      controller: _amountController,
      keyboardType: TextInputType.text,
      readOnly: true,
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      decoration: const InputDecoration(
        labelText: "Amount",
        hintText: "Enter desired option amount",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildCardNumberFormField() {
    return TextFormField(
      keyboardType: TextInputType.number,
      onSaved: (newValue) => cardNumber = newValue,
      maxLength: 16,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: cardNumberRequiredError);
        } else if (value.length == 16) {
          removeError(error: cardNumberLengthError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: cardNumberRequiredError);
          return "";
        } else if (value.length < 16) {
          addError(error: cardNumberLengthError);
          return "";
        }
        return null;
      },
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      decoration: const InputDecoration(
        labelText: "Card Number",
        hintText: "Enter valid card number",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildCvvFormField() {
    return TextFormField(
      keyboardType: TextInputType.number,
      onSaved: (newValue) => cvv = newValue,
      maxLength: 3,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: cvvRequiredError);
        } else if (value.length == 3) {
          removeError(error: cvvLengthError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: cvvRequiredError);
          return "";
        } else if (value.length < 2) {
          addError(error: cvvLengthError);
          return "";
        }
        return null;
      },
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      decoration: const InputDecoration(
        labelText: "CVV Number",
        hintText: "Enter Your CVV Number",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildExpiryMonthFormField() {
    return TextFormField(
      keyboardType: TextInputType.number,
      onSaved: (newValue) => expiryMonth = newValue,
      maxLength: 2,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: expiryDateMonthRequiredError);
        }

        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: expiryDateMonthRequiredError);
          return "";
        }

        return null;
      },
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      decoration: const InputDecoration(
        labelText: "Expiry Month Date",
        hintText: "Expiry Month Date",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildExpiryYearFormField() {
    return TextFormField(
      keyboardType: TextInputType.number,
      onSaved: (newValue) => expiryYear = newValue,
      maxLength: 2,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: expiryDateYearRequiredError);
        }

        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: expiryDateYearRequiredError);
          return "";
        }

        return null;
      },
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      decoration: const InputDecoration(
        labelText: "Expiry Year Date",
        hintText: "Expiry Year Date",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }
}
