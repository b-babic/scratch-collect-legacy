import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/home/models/category.model.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';

class Categories extends StatefulWidget {
  final Function? onCategoryChange;
  final int selectedCategory;

  const Categories({
    Key? key,
    this.onCategoryChange,
    required this.selectedCategory,
  }) : super(key: key);

  @override
  CategoriesState createState() => CategoriesState();
}

class CategoriesState extends State<Categories> {
  // TODO: Fetch from API and default to custom list if neccessary
  List<Category> categories = [
    Category(id: 1, name: "Luxury"),
    Category(id: 2, name: "Sports"),
    Category(id: 3, name: "Food"),
    Category(id: 4, name: "Travel"),
  ];

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 20),
      child: SizedBox(
        height: 30,
        child: ListView.builder(
          scrollDirection: Axis.horizontal,
          itemCount: categories.length,
          itemBuilder: (context, index) => buildCategory(categories[index]),
        ),
      ),
    );
  }

  Widget buildCategory(Category category) {
    return GestureDetector(
      onTap: () {
        widget.onCategoryChange!(category.id);
      },
      child: Padding(
        padding: const EdgeInsets.fromLTRB(0, 0, 20, 0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            Text(
              category.name ?? "",
              style: TextStyle(
                fontWeight: FontWeight.bold,
                color: widget.selectedCategory == category.id
                    ? primaryColor
                    : textColor,
              ),
            ),
            Container(
              margin: const EdgeInsets.only(top: 40 / 4), //top padding 5
              height: 2,
              width: 30,
              color: widget.selectedCategory == category.id
                  ? textColor
                  : Colors.transparent,
            )
          ],
        ),
      ),
    );
  }
}
