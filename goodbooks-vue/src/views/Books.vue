<template>
  <div class="books-container">
    <h1>My Books</h1>
    <div v-if="myBooks.length">
      <ol>
        <li v-for="book in myBooks" :key="book.id">{{ book.title }}</li>
      </ol>
      <v-list-item two-line>
      <v-list-item-content>
        <v-list-item-title>Two-line item</v-list-item-title>
        <v-list-item-subtitle>Secondary text</v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>
    </div>
  </div>
</template>

<script lang="ts">
  import BookService from "@/services/book-service";
  import IBook from "@/types/Book";
  import { Component, Vue } from 'vue-property-decorator';

  const bookService = new BookService();

  @Component({
    name: 'MyBooks',
    components: {}
  })
  export default class MyBooks extends Vue {
    // data
    myBooks: IBook[] = [];

    // computed properties
    get bookCount() {
      return this.myBooks.length
    }

    // lifecycle hooks
    created() {
      bookService.getAllBooks()
        .then(res => {
          this.myBooks = res;
          console.log(this.myBooks);
        })
        .catch(err => console.error(err));
    }

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
  h3 {
    margin: 40px 0 0;
  }
  ul {
    list-style-type: none;
    padding: 0;
  }
  li {
    display: inline-block;
    margin: 0 10px;
  }
  a {
    color: #42b983;
  }
</style>
