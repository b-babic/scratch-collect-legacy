class Voucher {
  int? id;
  String? text;
  String? value;
  String? createdAt;

  Voucher({
    this.id,
    this.text,
    this.value,
    this.createdAt,
  });

  Voucher.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    text = json['text'];
    value = json['value'];
    createdAt = json['createdAt'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['text'] = text;
    data['value'] = value;
    data['createdAt'] = createdAt;

    return data;
  }
}
