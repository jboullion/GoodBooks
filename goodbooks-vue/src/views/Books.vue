<template>
  <v-container>
    <h1 class="mb-2">My Books</h1>

    <v-row v-if="myBooks.length">
      <v-col cols="12">
        <v-list two-line nav>
          <BookListItem v-for="book in myBooks" :key="book.id" :book="book" @reloadBooks="loadBooks"></BookListItem>
        </v-list>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
  import BookService from "@/services/book-service";
  import IBook from "@/types/Book";
  import BookListItem from "@/components/BookListItem.vue"
  import { Component, Vue } from 'vue-property-decorator';

  const bookService = new BookService();

  @Component({
    name: 'MyBooks',
    components: {
      BookListItem
    }
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
      this.loadBooks();
    }

    loadBooks(){
       bookService.getAllBooks()
        .then(res => {
          this.myBooks = res;
          //console.log(this.myBooks);
        })
        .catch(err => console.error(err));
    }

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
