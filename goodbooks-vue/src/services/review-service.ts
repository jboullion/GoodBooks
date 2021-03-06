import axios from 'axios';
import IReview from "@/types/Review"

export default class ReviewService {
	API_URL = process.env.VUE_APP_API_URL;

	public async getAllBookReviews(): Promise<IReview[]> {
		const result = await axios.get(`${this.API_URL}/reviews/`);
		return result.data;
	}

	public async getBookReview(reviewId: number) {
		const result = await axios.get(`${this.API_URL}/reviews/${reviewId}`);
		return result.data;
	}

	public async addBookReview(review: IReview) {
		const result = await axios.post(`${this.API_URL}/reviews/`, review);
		return result.data;
	}

	public async deleteBookReview(reviewId: number) {
		const result = await axios.delete(`${this.API_URL}/reviews/${reviewId}`);
		return result.data;
	}

	
}