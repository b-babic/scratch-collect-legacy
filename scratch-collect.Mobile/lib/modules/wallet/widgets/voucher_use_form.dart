// ignore_for_file: use_build_context_synchronously

import 'package:flutter/material.dart';
import 'package:IB210370/modules/auth/constants.dart';
import 'package:IB210370/modules/profile/services/profile.service.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/utils/keyboard.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/shared/widgets/form_error.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';
import 'package:IB210370/modules/wallet/models/use_voucher_request.dart';
import 'package:IB210370/modules/wallet/services/voucher.service.dart';

class VoucherUseForm extends StatefulWidget {
  const VoucherUseForm({Key? key}) : super(key: key);

  @override
  VoucherUseFormState createState() => VoucherUseFormState();
}

class VoucherUseFormState extends State<VoucherUseForm> {
  final _formKey = GlobalKey<FormState>();

  String? voucher;

  final List<String?> errors = [];

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
            buildVoucherField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            FormError(errors: errors),
            SizedBox(height: getProportionateScreenHeight(60)),
            Button(
              text: "Use Voucher",
              press: () async {
                if (_formKey.currentState!.validate()) {
                  _formKey.currentState!.save();

                  KeyboardUtil.hideKeyboard(context);

                  clearErrors();

                  try {
                    final profile =
                        await ProfileService().getPersistedProfile();

                    var request = UseVoucherRequest(
                      userId: profile.id.toString(),
                      walletId: profile.wallet?.id.toString(),
                      coupon: voucher,
                    );

                    var response = await VoucherService().useCoupon(request);

                    if (response.id != null) {
                      Snackbar.showSuccess(context, "Coupon used!");
                    } else {
                      Snackbar.showError(context, "Something went wrong!");
                    }
                  } on Exception catch (e) {
                    Snackbar.showError(context, e.toString());
                  }
                }
              },
            )
          ],
        ));
  }

  TextFormField buildVoucherField() {
    return TextFormField(
      onSaved: (newValue) => voucher = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: voucherRequiredError);
        } else if (value.length == 9) {
          removeError(error: voucherLengthError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: voucherRequiredError);
          return "";
        } else if (value.length != 9) {
          addError(error: voucherLengthError);
          return "";
        }
      },
      decoration: const InputDecoration(
        labelText: "Voucher",
        hintText: 'Enter voucher code',
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }
}
